using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Api.Data;
using FitnessTracker.Api.Models;

namespace FitnessTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly FitnessTrackerContext _context;

        public ActivitiesController(FitnessTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _context.Activities.Include(a => a.User).ToListAsync();
            return Ok(activities);
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(int id)
        {
            var activity = await _context.Activities.Include(a => a.User).FirstOrDefaultAsync(a => a.Id == id);
            if (activity == null) return NotFound();

            return Ok(activity);
        }

        // POST: api/Activities
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetActivity), new { id = activity.Id }, activity);
        }

        // PUT: api/Activities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, Activity activity)
        {
            if (id != activity.Id) return BadRequest();

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Activities.Any(a => a.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return NotFound();

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
