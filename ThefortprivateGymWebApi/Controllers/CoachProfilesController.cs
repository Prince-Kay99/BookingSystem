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
    public class CoachProfilesController : ControllerBase
    {
        private readonly TheFortContext _context;

        public CoachProfilesController(TheFortContext context)
        {
            _context = context;
        }

        private bool CoachProfileExists(int id)
        {
            return (_context.CoachProfiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        //all coaches
        // GET: api/CoachProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachProfile>>> GetCoachProfiles()
        {
            if (_context.CoachProfiles == null)
            {
                return NotFound();
            }
            return await _context.CoachProfiles.ToListAsync();
        }

        //get coaches by id 
        // GET: api/CoachProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachProfile>> GetCoachProfile(int id)
        {
            if (_context.CoachProfiles == null)
            {
                return NotFound();
            }
            var coachProfile = await _context.CoachProfiles.FindAsync(id);

            if (coachProfile == null)
            {
                return NotFound();
            }

            return coachProfile;
        }

        //edit coach 
        // PUT: api/CoachProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoachProfile(int id, CoachProfile coachProfile)
        {
            if (id != coachProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(coachProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachProfileExists(id))
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

        //adding a coach
        // POST: api/CoachProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoachProfile>> PostCoachProfile(CoachProfile coachProfile)
        {
            if (_context.CoachProfiles == null)
            {
                return Problem("Entity set 'TheFortContext.CoachProfiles'  is null.");
            }
            _context.CoachProfiles.Add(coachProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoachProfile", new { id = coachProfile.Id }, coachProfile);
        }

        //remove coach
        // DELETE: api/CoachProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoachProfile(int id)
        {
            if (_context.CoachProfiles == null)
            {
                return NotFound();
            }
            var coachProfile = await _context.CoachProfiles.FindAsync(id);
            if (coachProfile == null)
            {
                return NotFound();
            }

            _context.CoachProfiles.Remove(coachProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //get coach by age
        [HttpGet("{userAge}")]
        public async Task<List<CoachProfile>> getCoachAgeAsync(int userAGE)
        {
            List<CoachProfile> list = new List<CoachProfile>();

            var coaches = (from c in _context.CoachProfiles
                           where c.Age > userAGE
                           select c).DefaultIfEmpty();

            foreach (CoachProfile coach in coaches)
            {
                var newcoach = new CoachProfile
                {
                    Id = coach.Id,
                    Age = coach.Age,
                    Branch = coach.Branch,
                    Qualification = coach.Qualification,
                    Personality = coach.Personality,
                    Experience = coach.Experience,
                    Rating = coach.Rating,
                };
                list.Add(newcoach);

            }
            return list;

        }


        /**[HttpPost]
        [Route("addCoachToClientProfile")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> addCoachToClientProfileAsync(ClientCoachPair pair)
        {

            var coachProfile = await _context.CoachProfiles.FindAsync(pair.CoachId);
            var clientProfile = await _context.ClientProfiles.FindAsync(pair.CoachId);

            if (pair.CoachId != coachProfile.Id)
            {
                return BadRequest();
            }

            if (pair.ClientId != clientProfile.Id)
            {
                return BadRequest();
            }

            var dbProfile = await _context.ClientProfiles.FindAsync(pair.ClientId);

            dbProfile.AGE = clientProfile.AGE;
            dbProfile.COACH_ID = pair.CoachId;
            dbProfile.DESIREDWEIGHT = clientProfile.DESIREDWEIGHT;
            dbProfile.CURRENTWEIGHT = clientProfile.CURRENTWEIGHT;
            dbProfile.PERSONALITY = clientProfile.PERSONALITY;
            dbProfile.DISABILITY = clientProfile.DISABILITY;
            dbProfile.ClientId = clientProfile.ClientId;

            if (pair.CoachId != coachProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(dbProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachProfileExists(pair.ClientId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }**/


    
      

    }
}
