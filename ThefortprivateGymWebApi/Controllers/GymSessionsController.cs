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
    [Route("api/[controller]")]
    [ApiController]
    public class GymSessionsController : ControllerBase
    {
        private readonly TheFortContext _context;

        public GymSessionsController(TheFortContext context)
        {
            _context = context;
        }

        // GET: api/GymSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymSession>>> GetGymSessions()
        {
          if (_context.GymSessions == null)
          {
              return NotFound();
          }
            return await _context.GymSessions.ToListAsync();
        }




        // GET: api/GymSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymSession>> GetGymSession(int id)
        {
          if (_context.GymSessions == null)
          {
              return NotFound();
          }
            var gymSession = await _context.GymSessions.FindAsync(id);

            if (gymSession == null)
            {
                return NotFound();
            }

            return gymSession;
        }

        // PUT: api/GymSessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGymSession(int id, GymSession gymSession)
        {
            if (id != gymSession.Id)
            {
                return BadRequest();
            }

            _context.Entry(gymSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymSessionExists(id))
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

        // POST: api/GymSessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GymSession>> PostGymSession(GymSession gymSession)
        {
          if (_context.GymSessions == null)
          {
              return Problem("Entity set 'TheFortContext.GymSessions'  is null.");
          }
            _context.GymSessions.Add(gymSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGymSession", new { id = gymSession.Id }, gymSession);
        }

        // DELETE: api/GymSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymSession(int id)
        {
            if (_context.GymSessions == null)
            {
                return NotFound();
            }
            var gymSession = await _context.GymSessions.FindAsync(id);
            if (gymSession == null)
            {
                return NotFound();
            }

            _context.GymSessions.Remove(gymSession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GymSessionExists(int id)
        {
            return (_context.GymSessions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
