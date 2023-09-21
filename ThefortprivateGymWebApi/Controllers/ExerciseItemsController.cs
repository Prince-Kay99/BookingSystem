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
    public class ExerciseItemsController : ControllerBase
    {
        private readonly TheFortContext _context;

        public ExerciseItemsController(TheFortContext context)
        {
            _context = context;
        }

        // GET: api/ExerciseItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseItem>>> GetExerciseItems()
        {
          if (_context.ExerciseItems == null)
          {
              return NotFound();
          }
            return await _context.ExerciseItems.ToListAsync();
        }

        // GET: api/ExerciseItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseItem>> GetExerciseItem(int id)
        {
          if (_context.ExerciseItems == null)
          {
              return NotFound();
          }
            var exerciseItem = await _context.ExerciseItems.FindAsync(id);

            if (exerciseItem == null)
            {
                return NotFound();
            }

            return exerciseItem;
        }

        // PUT: api/ExerciseItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseItem(int id, ExerciseItem exerciseItem)
        {
            if (id != exerciseItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(exerciseItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseItemExists(id))
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

        // POST: api/ExerciseItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExerciseItem>> PostExerciseItem(ExerciseItem exerciseItem)
        {
          if (_context.ExerciseItems == null)
          {
              return Problem("Entity set 'TheFortContext.ExerciseItems'  is null.");
          }
            _context.ExerciseItems.Add(exerciseItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExerciseItem", new { id = exerciseItem.Id }, exerciseItem);
        }

        // DELETE: api/ExerciseItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseItem(int id)
        {
            if (_context.ExerciseItems == null)
            {
                return NotFound();
            }
            var exerciseItem = await _context.ExerciseItems.FindAsync(id);
            if (exerciseItem == null)
            {
                return NotFound();
            }

            _context.ExerciseItems.Remove(exerciseItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseItemExists(int id)
        {
            return (_context.ExerciseItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
