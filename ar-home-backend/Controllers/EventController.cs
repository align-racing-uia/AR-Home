using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models.Info;

namespace web_api.Controllers
{
    [Route("info/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: info/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }
        
        // GET: info/events/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            
            if (evnt == null)
            {
                return NotFound();
            }

            return evnt;
        }
        
        // PUT: info/events/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event evnt)
        {
            if (id != evnt.Id)
            {
                return BadRequest();
            }

            _context.Entry(evnt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        
        // POST: info/events
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event evnt)
        {
            _context.Events.Add(evnt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvents", new {id = evnt.Id}, evnt);
        }
        
        // DELETE: info/events/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            var evnt = await _context.Events.FindAsync(id);
            if (evnt == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evnt);
            
            await _context.SaveChangesAsync();

            return evnt;
        }
        
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}