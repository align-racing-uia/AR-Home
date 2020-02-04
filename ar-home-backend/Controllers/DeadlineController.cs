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
    [Route("info/deadlines")]
    [ApiController]
    public class DeadlineController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeadlineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: info/deadlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deadline>>> GetDeadlines()
        {
            return await _context.Deadlines.ToListAsync();
        }
        
        // GET: info/deadlines/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Deadline>> GetDeadline(int id)
        {
            var deadline = await _context.Deadlines.FindAsync(id);
            
            if (deadline == null)
            {
                return NotFound();
            }

            return deadline;
        }
        
        // PUT: info/deadlines/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeadline(int id, Deadline deadline)
        {
            if (id != deadline.Id)
            {
                return BadRequest();
            }

            _context.Entry(deadline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeadlineExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        
        // POST: info/deadlines
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Deadline>> PostDeadline(Deadline deadline)
        {
            _context.Deadlines.Add(deadline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeadline", new {id = deadline.Id}, deadline);
        }
        
        // DELETE: info/deadlines/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Deadline>> DeleteDeadline(int id)
        {
            var deadline = await _context.Deadlines.FindAsync(id);
            if (deadline == null)
            {
                return NotFound();
            }

            _context.Deadlines.Remove(deadline);
            
            await _context.SaveChangesAsync();

            return deadline;
        }
        
        private bool DeadlineExists(int id)
        {
            return _context.Deadlines.Any(e => e.Id == id);
        }
    }
}