using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI1.Data;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonhocsController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public MonhocsController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/Monhocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monhoc>>> GetMonhocs()
        {
            return await _context.Monhocs.ToListAsync();
        }

        // GET: api/Monhocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monhoc>> GetMonhoc(int id)
        {
            var monhoc = await _context.Monhocs.FindAsync(id);

            if (monhoc == null)
            {
                return NotFound();
            }

            return monhoc;
        }

        // PUT: api/Monhocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonhoc(int id, Monhoc monhoc)
        {
            if (id != monhoc.MaMon)
            {
                return BadRequest();
            }

            _context.Entry(monhoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonhocExists(id))
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

        // POST: api/Monhocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Monhoc>> PostMonhoc(Monhoc monhoc)
        {
            _context.Monhocs.Add(monhoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonhoc", new { id = monhoc.MaMon }, monhoc);
        }

        // DELETE: api/Monhocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonhoc(int id)
        {
            var monhoc = await _context.Monhocs.FindAsync(id);
            if (monhoc == null)
            {
                return NotFound();
            }

            _context.Monhocs.Remove(monhoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonhocExists(int id)
        {
            return _context.Monhocs.Any(e => e.MaMon == id);
        }
    }
}
