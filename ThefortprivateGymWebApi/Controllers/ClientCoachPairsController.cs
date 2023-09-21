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
    public class ClientCoachPairsController : ControllerBase
    {
        private readonly TheFortContext _context;

        public ClientCoachPairsController(TheFortContext context)
        {
            _context = context;
        }
        //Post client-coach Pair
        [HttpPost("addPairs")]
        public async Task<IActionResult> addPair(ClientCoachPair model)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            // Create a new ClientCoachPair record
            var newPair = new ClientCoachPair
            {
                CoachId = model.CoachId, // Assuming you have the CoachId in the User model
                ClientId = model.ClientId // Assuming Id is the generated ID for the new user
            };

            // Add the new ClientCoachPair record to the context
            _context.ClientCoachPairs.Add(newPair);
            await _context.SaveChangesAsync();

            return Ok("successful.");
        }
        // GET: api/ClientCoachPairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientCoachPair>>> GetClientCoachPairs()
        {
          if (_context.ClientCoachPairs == null)
          {
              return NotFound();
          }
            return await _context.ClientCoachPairs.ToListAsync();
        }

        // GET: api/ClientCoachPairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientCoachPair>> GetClientCoachPair(int id)
        {
          if (_context.ClientCoachPairs == null)
          {
              return NotFound();
          }
            var clientCoachPair = await _context.ClientCoachPairs.FindAsync(id);

            if (clientCoachPair == null)
            {
                return NotFound();
            }

            return clientCoachPair;
        }
        //Get the coach id for client coach assignment
        [HttpGet("GetCoachIdByClientId/{id}")]
        public ActionResult<int?> GetCoachIdByClientId(int id)
        {
            var clientCoachPair = _context.ClientCoachPairs.FirstOrDefault(pair => pair.ClientId == id);

            if (clientCoachPair == null)
            {
                return null;
            }

            return clientCoachPair.CoachId;
        }
        // PUT: api/ClientCoachPairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientCoachPair(int id, ClientCoachPair clientCoachPair)
        {
            if (id != clientCoachPair.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientCoachPair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientCoachPairExists(id))
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

        // POST: api/ClientCoachPairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientCoachPair>> PostClientCoachPair(ClientCoachPair clientCoachPair)
        {
          if (_context.ClientCoachPairs == null)
          {
              return Problem("Entity set 'TheFortContext.ClientCoachPairs'  is null.");
          }
            _context.ClientCoachPairs.Add(clientCoachPair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientCoachPair", new { id = clientCoachPair.Id }, clientCoachPair);
        }

        // DELETE: api/ClientCoachPairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientCoachPair(int id)
        {
            if (_context.ClientCoachPairs == null)
            {
                return NotFound();
            }
            var clientCoachPair = await _context.ClientCoachPairs.FindAsync(id);
            if (clientCoachPair == null)
            {
                return NotFound();
            }

            _context.ClientCoachPairs.Remove(clientCoachPair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientCoachPairExists(int id)
        {
            return (_context.ClientCoachPairs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
