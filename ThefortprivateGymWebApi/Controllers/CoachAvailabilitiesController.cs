using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThefortprivateGymWebApi.Data;
using ThefortprivateGymWebApi.Models;

namespace ThefortprivateGymWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoachAvailabilitiesController : ControllerBase
    {
        private readonly TheFortContext _context;

        public CoachAvailabilitiesController(TheFortContext context)
        {
            _context = context;
        }

        // GET: api/CoachAvailabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachAvailability>>> GetCoachAvailabilitys()
        {
          if (_context.CoachAvailabilitys == null)
          {
              return NotFound();
          }
            return await _context.CoachAvailabilitys.ToListAsync();
        }
        // GET: api/CoachAvailabilities/5
        [HttpGet]
        public async Task<ActionResult<List<CoachAvailability>>> GetCoachByIdAvailability(int coachID)
        {
            if (_context.CoachAvailabilitys == null)
            {
                return NotFound();
            }
            var coachAvailability = await _context.CoachAvailabilitys.Where(c=> c.Coach_Id ==coachID).ToListAsync();

            if (coachAvailability == null)
            {
                return NotFound();
            }

            return coachAvailability;
        }
        // GET: api/CoachAvailabilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachAvailability>> GetCoachAvailability(int id)
        {
          if (_context.CoachAvailabilitys == null)
          {
              return NotFound();
          }
            var coachAvailability = await _context.CoachAvailabilitys.FindAsync(id);

            if (coachAvailability == null)
            {
                return NotFound();
            }

            return coachAvailability;
        }

        // PUT: api/CoachAvailabilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoachAvailability(int id, CoachAvailability coachAvailability)
        {
            if (id != coachAvailability.Id)
            {
                return BadRequest();
            }

            _context.Entry(coachAvailability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachAvailabilityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CoachAvailabilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoachAvailability>> PostCoachAvailability(CoachAvailability coachAvailability)
        {
          if (_context.CoachAvailabilitys == null)
          {
              return Problem("Entity set 'TheFortContext.CoachAvailabilitys'  is null.");
          }
            _context.CoachAvailabilitys.Add(coachAvailability);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoachAvailability", new { id = coachAvailability.Id }, coachAvailability);
        }

        // DELETE: api/CoachAvailabilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoachAvailability(int id)
        {
            if (_context.CoachAvailabilitys == null)
            {
                return NotFound();
            }
            var coachAvailability = await _context.CoachAvailabilitys.FindAsync(id);
            if (coachAvailability == null)
            {
                return NotFound();
            }

            _context.CoachAvailabilitys.Remove(coachAvailability);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachAvailabilityExists(int id)
        {
            return (_context.CoachAvailabilitys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
