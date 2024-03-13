using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProductosWeb.Context;
using APIProductosWeb.Models;

namespace APIProductosWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categories_DBController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Categories_DBController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories_DB
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories_DB>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Categories_DB/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories_DB>> GetCategories_DB(int id)
        {
            var categories_DB = await _context.Categories.FindAsync(id);

            if (categories_DB == null)
            {
                return NotFound();
            }

            return categories_DB;
        }

        // PUT: api/Categories_DB/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories_DB(int id, Categories_DB categories_DB)
        {
            if (id != categories_DB.CategoryID)
            {
                return BadRequest();
            }

            _context.Entry(categories_DB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Categories_DBExists(id))
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

        // POST: api/Categories_DB
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categories_DB>> PostCategories_DB(Categories_DB categories_DB)
        {
            _context.Categories.Add(categories_DB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategories_DB", new { id = categories_DB.CategoryID }, categories_DB);
        }

        // DELETE: api/Categories_DB/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategories_DB(int id)
        {
            var categories_DB = await _context.Categories.FindAsync(id);
            if (categories_DB == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categories_DB);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Categories_DBExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
