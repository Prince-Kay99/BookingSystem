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
    public class CoachesSessionsController : ControllerBase
    {
        private readonly TheFortContext _context;

        public CoachesSessionsController(TheFortContext context)
        {
            _context = context;
        }
        [HttpGet("getSessions")]
        public async Task<ActionResult<IEnumerable<CoachesSession>>> getSessions()
        {
            // Assuming _context.CoachesSessions is your DbContext's DbSet<CoachesSession>
            var bookedSessions = await _context.CoachesSessions
                .Where(session => session.booked == 0)
                .ToListAsync();

            if (bookedSessions == null || bookedSessions.Count == 0)
            {
                return NotFound();
            }

            return bookedSessions;
        }
        [HttpGet("GetCoachWithMostSessionsByDays/{days}")]
        public ActionResult<int?> GetCoachWithMostSessionsByDays(int days)
        {
            var weekdays = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            var selectedDays = new List<string>();

            string daysStr = days.ToString();
            for (int i = 0; i < daysStr.Length; i++)
            {
                int digit = int.Parse(daysStr[i].ToString());
                if (digit >= 1 && digit <= 7)
                {
                    selectedDays.Add(weekdays[digit - 1]);
                }
            }

            var coachSessionsCount = _context.CoachesSessions
                .Where(session => selectedDays.Contains(session.day))
                .GroupBy(session => session.coachId)
                .Select(group => new { CoachId = group.Key, SessionCount = group.Count() })
                .OrderByDescending(group => group.SessionCount)
                .FirstOrDefault();

            if (coachSessionsCount == null)
            {
                return NotFound();
            }

            return coachSessionsCount.CoachId;
        }

    }
}
