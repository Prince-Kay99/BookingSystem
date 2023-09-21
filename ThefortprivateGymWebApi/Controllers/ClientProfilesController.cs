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
    public class ClientProfilesController : ControllerBase
    {
        private readonly TheFortContext _context;

        public ClientProfilesController(TheFortContext context)
        {
            _context = context;
        }

       
        //Get client Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientProfile>>> GetClientProfiles()
        {
            var clientProfiles = await _context.ClientProfiles
                                 .Where(profile => profile.COACH_ID == 0)
                                 .ToListAsync() ;

            if (clientProfiles.Count == 0)
            {
                return null;
            }

            return clientProfiles;
        }


        // GET: api/ClientProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientProfile>> GetClientProfile(int id)
        {
            if (_context.ClientProfiles == null)
            {
                return NotFound();
            }
            var clientProfile = await _context.ClientProfiles.FindAsync(id);

            if (clientProfile == null)
            {
                return NotFound();
            }

            return clientProfile;
        }

        //Get profile Id
        [HttpGet("GetClientProfile/{clientId}")]
        public async Task<ActionResult<int>> GetClientProfileID(int clientId)
        {
            if (_context.ClientProfiles == null)
            {
                return NotFound();
            }
            // Find the client profile based on the provided clientId
            var clientProfile = await _context.ClientProfiles
                .Where(profile => profile.ClientId == clientId)
                .FirstOrDefaultAsync();

            if (clientProfile == null)
            {
                return NotFound();
            }

            // Return the primary key (Id) of the client profile as an int
            return clientProfile.Id;
        }

        // PUT: api/ClientProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientProfile(int id, ClientProfile clientProfile)
        {
            if (id != clientProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientProfileExists(id))
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

        // POST: api/ClientProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientProfile>> PostClientProfile(ClientProfile clientProfile)
        {
          if (_context.ClientProfiles == null)
          {
              return Problem("Entity set 'TheFortContext.ClientProfiles'  is null.");
          }
            _context.ClientProfiles.Add(clientProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientProfile", new { id = clientProfile.Id }, clientProfile);
        }

        [HttpPut("{coachId}")]
        public async Task<IActionResult> UpdateClientProfileCoach([FromBody] ClientProfile clientProfile, int coachId)
        {
            // Check if the provided clientProfile is null
            if (clientProfile == null)
            {
                return BadRequest("Invalid client profile data.");
            }

            // Update the COACH_ID property with the new coach ID
            clientProfile.COACH_ID = coachId;

            // Set the state of the provided clientProfile as modified
            _context.Entry(clientProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(clientProfile); // Return the updated client profile on success
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception if needed
                return BadRequest("Failed to update the client profile.");
            }
        }
        /**[HttpPut("{coachId}")]
        public async Task<IActionResult> UpdateClientProfileCoachss(ClientProfile clientProfile, int coachId)
        {
            // Check if the provided clientProfile is null
            if (clientProfile == null)
            {
                return BadRequest("Invalid client profile data.");
            }

            // Load the existing client profile from the database based on the provided Id
            var existingClientProfile = await _context.ClientProfiles.FindAsync(id);

            if (existingClientProfile == null)
            {
                return NotFound("Client profile not found.");
            }

            // Update the COACH_ID property with the new coach ID
            existingClientProfile.COACH_ID = coachId;

            // Set the state of the existing client profile as modified
            _context.Entry(existingClientProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(existingClientProfile); // Return the updated client profile on success
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception if needed
                return BadRequest("Failed to update the client profile.");
            }
        }**/

        // DELETE: api/ClientProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientProfile(int id)
        {
            if (_context.ClientProfiles == null)
            {
                return NotFound();
            }
            var clientProfile = await _context.ClientProfiles.FindAsync(id);
            if (clientProfile == null)
            {
                return NotFound();
            }

            _context.ClientProfiles.Remove(clientProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
     
        private bool ClientProfileExists(int id)
        {
            return (_context.ClientProfiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        [HttpGet]
        [Route("GymActiveSessions")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public async Task<double> GetPercentageOfClientsWithoutCoachAsync()
        { 
        // GET: api/GymActiveSessions
     
            // Get the total count of entries in the database
           
            var totalCount =  await _context.ClientProfiles.CountAsync();
            /// </summary>

            // Get the count of entries where COACH_ID is null
            int clientsWithoutCoachCount = await _context.ClientProfiles.Where(c => c.COACH_ID == -1).CountAsync();

            // Calculate the percentage
            double percentage = (double)clientsWithoutCoachCount / totalCount * 100;

            // Round the percentage to two decimal places
            double roundedPercentage = Math.Round(percentage, 2);

            return  roundedPercentage;
       }
    }
}
