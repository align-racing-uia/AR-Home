using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
using web_api.Models;
using web_api.Models.Home;

namespace web_api.Controllers
{
    [Route("home/Shortcuts")]
    [ApiController]
    public class ShortcutsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShortcutsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Shortcuts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shortcut>>> GetShortcuts()
        {

            return await _context.Shortcuts.ToListAsync();
        }

        // GET: api/Shortcuts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shortcut>> GetShortcut(int id)
        {
            var Shortcut = await _context.Shortcuts.FindAsync(id);
            
            if (Shortcut == null)
            {
                return NotFound();
            }

            return Shortcut;
        }

        // PUT: api/Shortcuts/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShortcut(int id, Shortcut Shortcut)
        {
            if (id != Shortcut.Id)
            {
                return BadRequest();
            }

            _context.Entry(Shortcut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShortcutExists(id))
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

        // POST: api/Shortcuts
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Shortcut>> PostShortcut(Shortcut Shortcut)
        {
            _context.Shortcuts.Add(Shortcut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShortcut", new {id = Shortcut.Id}, Shortcut);
        }



        // DELETE: api/Rooms/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shortcut>> DeleteShortcut(int id)
        {
            var room = await _context.Shortcuts.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Shortcuts.Remove(room);
            
            
            
            await _context.SaveChangesAsync();

            return room;
        }

        private bool ShortcutExists(int id)
        {
            return _context.Shortcuts.Any(e => e.Id == id);
        }
    }
}