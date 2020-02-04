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
    [Route("home/Categories")]
    [ApiController]
    public class CategorysApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategorysApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategorys()
        {

            return await _context.Categorys.ToListAsync();
        }

        // GET: api/Categorys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var Category = await _context.Categorys.FindAsync(id);
            
            if (Category == null)
            {
                return NotFound();
            }

            return Category;
        }

        // PUT: api/Categorys/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category Category)
        {
            if (id != Category.Id)
            {
                return BadRequest();
            }

            _context.Entry(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categorys
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category Category)
        {
            _context.Categorys.Add(Category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new {id = Category.Id}, Category);
        }



        // DELETE: api/Rooms/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var room = await _context.Categorys.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Categorys.Remove(room);
            
            
            
            await _context.SaveChangesAsync();

            return room;
        }

        private bool CategoryExists(int id)
        {
            return _context.Categorys.Any(e => e.Id == id);
        }
    }
}