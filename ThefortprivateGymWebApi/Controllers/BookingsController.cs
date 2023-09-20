using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HashPass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThefortprivateGymWebApi.Data;
using ThefortprivateGymWebApi.Dto;
using ThefortprivateGymWebApi.Models;

namespace ThefortprivateGymWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly TheFortContext _context;

        public BookingsController(TheFortContext context)
        {
            _context = context;
        }

        // GET: api/CoachProfile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachObject>>> GetCoaches()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }
        // GET: api/Users/5
        [HttpGet("{login}")]
        public async Task<ActionResult<UserDto>> Login(Login login)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FirstOrDefaultAsync(c=>c.User_Email == login.Username && c.User_Password == Secrecy.HashPassword(login.Password));

            if (user == null)
            {
                return NotFound();
            }
            UserDto userdto = new UserDto()
            {
                Id = user.Id,
                User_FirstName = user.User_FirstName,
                User_LastName = user.User_LastName,
                User_Contact = user.User_Contact,
                User_Email = user.User_Email,
                User_Type = user.User_Type,
            };
            return userdto;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(User model)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the user already exists
            if (await _context.Users.AnyAsync(u => u.User_Email == model.User_Email))
            {
                return BadRequest("Username is already taken.");
            }

            // Create a new user (you should hash the password before storing)
            var newUser = new User
            {
                User_FirstName = model.User_FirstName,
                User_LastName = model.User_LastName,
                User_Contact = model.User_Contact,
                User_Email = model.User_Email,
                // Hash and salt the password before saving
                User_Password = Secrecy.HashPassword(model.User_Password),
                User_Type = "Client"
                // Include other user properties as needed
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok("Registration successful.");
        }
            // POST: api/Users
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'TheFortContext.Users'  is null.");
          }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
