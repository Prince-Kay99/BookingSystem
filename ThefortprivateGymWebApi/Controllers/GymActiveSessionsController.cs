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
    public class GymActiveSessionsController : ControllerBase
    {
        private readonly TheFortContext _context;

        public GymActiveSessionsController(TheFortContext context)
        {
            _context = context;
        }


        [HttpDelete]
        [Route("deleteScheduleClient/{sessionId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> deleteScheduleClient(int sessionId)
        {

            if (_context.GymActiveSessions == null)
            {
                return NotFound();
            }
            var gymActiveSession = await _context.GymActiveSessions.FindAsync(sessionId);

            return CreatedAtAction("GetGymActiveSession", new { id = gymActiveSession.Id }, gymActiveSession);
        }

        private bool GymActiveSessionExists(int id)
        {
            return (_context.GymActiveSessions?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        [Route("getCoachUnbooked/{coachID}")]
        [ProducesResponseType(typeof(List<GymActiveSession>), StatusCodes.Status200OK)]
        public List<GymActiveSession> getCoachUnbooked(int coachID)
        {

            throw new NotImplementedException();
        }
        //done
        [HttpPost]
        [Route("PostAddSession")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> PostAddSession(int coachID, string start, string end, int attendance, int CoachAvailabilityID)
        {

            if (_context.GymActiveSessions == null)
            {
                return Problem("Entity set 'TheFortContext.GymActiveSessions' is null.");
            }

            try
            {
                var newUser = new GymActiveSession
                {
                    Coach_Id = coachID,
                    Client_Id = -1,
                    CoachAvailability_Id = CoachAvailabilityID,
                    Session_Attendance = attendance,
                };

                _context.GymActiveSessions.Add(newUser);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetGymActiveSession", new { id = newUser.Id }, newUser);
                // Add the new entry to the database

            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the database query
                ex.GetBaseException();
                return false;
            }
        }
        // GET: api/GymActiveSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymActiveSession>>> GetGymActiveSessions()
        {
            if (_context.GymActiveSessions == null)
            {
                return NotFound();
            }
            return await _context.GymActiveSessions.ToListAsync();
        }

        // GET: api/GymActiveSessions/5
        [HttpGet]
        public async Task<ActionResult<List<GymActiveSession>>> GetCoachGymActiveSession(int coachId)
        {
            if (_context.GymActiveSessions == null)
            {
                return NotFound();
            }
            var gymActiveSession = await _context.GymActiveSessions.Where(c => c.Coach_Id == coachId).ToListAsync();

            if (gymActiveSession == null)
            {
                return NotFound();
            }

            return gymActiveSession;
        }


        // GET: api/GymActiveSessions/5
        [HttpGet]
        public async Task<ActionResult<List<GymActiveSession>>> GetClientGymActiveSession(int clientId)
        {
            if (_context.GymActiveSessions == null)
            {
                return NotFound();
            }
            var gymActiveSession = await _context.GymActiveSessions.Where(c => c.Client_Id == clientId).ToListAsync();

            if (gymActiveSession == null)
            {
                return NotFound();
            }

            return gymActiveSession;
        }
        // GET: api/GymActiveSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymActiveSession>> GetGymActiveSession(int id)
        {
            if (_context.GymActiveSessions == null)
            {
                return NotFound();
            }
            var gymActiveSession = await _context.GymActiveSessions.FindAsync(id);

            if (gymActiveSession == null)
            {
                return NotFound();
            }

            return gymActiveSession;
        }



        [HttpPost]
        public async Task<ActionResult<GymActiveSession>> PostGymActiveSession(GymActiveSession gymActiveSession)
        {
            if (_context.GymActiveSessions == null)
            {
                return Problem("Entity set 'TheFortContext.GymActiveSessions'  is null.");
            }
            _context.GymActiveSessions.Add(gymActiveSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGymActiveSession", new { id = gymActiveSession.Id }, gymActiveSession);
        }

        [HttpPost("store")]
        public IActionResult StoreAppointment([FromBody] StoreAppointmentModel model)
        {
            try
            {
                // Find the appointment in the database by its ID
                var available = _context.CoachAvailabilitys.Find(model.CoachAvailability_Id);

                if (available != null)
                {
                    // Save changes to the database
                    GymActiveSession gymActiveSession = new GymActiveSession 
                    {
                        Coach_Id = available.Coach_Id,
                        Client_Id = model.Client_Id,
                        CoachAvailability_Id = available.Id,
                        Session_Attendance = 0
                    };

                    _context.GymActiveSessions.Add(gymActiveSession);

                    _context.SaveChanges();

                    return Ok(new {message = "Appointment booked successfully."});
                }
                else
                {   
                    return NotFound(new { message = "Appointment already booked." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing the request.", error = ex.Message });
            }
        }

        // PUT: api/GymActiveSessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /** [HttpPut("{id}")]
         public async Task<IActionResult> PutGymActiveSession(int id, GymActiveSession gymActiveSession)
         {
             if (id != gymActiveSession.Id)
             {
                 return BadRequest();
             }

             _context.Entry(gymActiveSession).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!GymActiveSessionExists(id))
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


         [HttpGet("coachWithMostZeroAttendance")]
         public ActionResult<int?> GetCoachWithMostZeroAttendance()

         private bool GymActiveSessionExists(int id)
         {
             return (_context.GymActiveSessions?.Any(e => e.Id == id)).GetValueOrDefault();
         }
    


         [HttpPut]
         [Route("UpdateSession/{Id}")]
         [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
         public async Task<ActionResult<bool>> UpdateSessionAsync(int Id, int clientID, int coachID, int coachAvailabilityID, string end, int attendance)
         {
             var coachWithMostZeroAttendance = _context.GymActiveSessions
                 .Where(session => session.SESSION_ATTENDANCE == 0)
                 .GroupBy(session => session.COACH_ID)
                 .OrderByDescending(group => group.Count())
                 .Select(group => group.Key)
                 .FirstOrDefault();

             if (coachWithMostZeroAttendance == null)
             {
                 return NotFound();
             }

             return coachWithMostZeroAttendance;
         }


     public async Task<ActionResult<bool>> UpdateSessionAsync(int Id, int clientID, int coachID, string start, string end, int attendance, string day)
     [HttpPut]
     [Route("UpdateSession/{Id}")]
     [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
     public async Task<ActionResult<bool>> UpdateSessionAsync(int Id, int clientID, int coachID, string start, string end, int attendance, string day)
     {

             var gymActiveSession = await _context.GymActiveSessions.FindAsync(Id);
             if (gymActiveSession == null)
             {

                 return BadRequest();
             }

             if (Id != gymActiveSession.Id)
             {
                 return BadRequest();
             }

             try
             {
                 gymActiveSession.Id = Id;
                 gymActiveSession.Coach_Id = coachID;
                 gymActiveSession.Client_Id = clientID;
                 gymActiveSession.CoachAvailability_Id = coachAvailabilityID;
                 gymActiveSession.Session_Attendance = attendance;


                 _context.Entry(gymActiveSession).State = EntityState.Modified;

                 try
                 {
                     await _context.SaveChangesAsync();
                     return true;
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!GymActiveSessionExists(Id))
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
             catch (DbUpdateConcurrencyException ex)
             {
                 if (Id != gymActiveSession.Id)
                 {
                     return BadRequest();
                 }
             }
         }*/


    }






    //done
    // POST: api/GymActiveSessions
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /** [HttpPost]
    
     [HttpPost]
     public async Task<ActionResult<GymActiveSession>> PostGymActiveSession(GymActiveSession gymActiveSession)
     {
       if (_context.GymActiveSessions == null)
       {
           return Problem("Entity set 'TheFortContext.GymActiveSessions'  is null.");
       }
         _context.GymActiveSessions.Add(gymActiveSession);
         await _context.SaveChangesAsync();
            _context.GymActiveSessions.Remove(gymActiveSession);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete]
        [Route("deleteScheduleClient/{sessionId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> deleteScheduleClient(int sessionId)
        { 
      
            if (_context.GymActiveSessions == null)
            {
                return NotFound();
            }
            var gymActiveSession = await _context.GymActiveSessions.FindAsync(sessionId);

         return CreatedAtAction("GetGymActiveSession", new { id = gymActiveSession.Id }, gymActiveSession);
     }
     //done
     [HttpPost]
     [Route("PostAddSession")]
     [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
     public async Task<ActionResult<bool>> PostAddSession(int coachID, string start, string end, int attendance, string day)
     {
    
         if (_context.GymActiveSessions == null)
         {
             return Problem("Entity set 'TheFortContext.GymActiveSessions' is null.");
         }

         try
         {
             var newUser = new GymActiveSession
             {
                 COACH_ID = coachID,
                 CLIENT_ID = -1,
                 SESSION_DAY = day,
                 SESSION_START = start,
                 SESSION_END = end,
                 SESSION_ATTENDANCE = attendance,
             };

             _context.GymActiveSessions.Add(newUser);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetGymActiveSession", new { id = newUser.Id }, newUser);
             // Add the new entry to the database
         
         }
         catch (Exception ex)
         {
             // Handle any exceptions that may occur during the database query
             ex.GetBaseException();
             return false;
         }
        }
     }**/
}

   