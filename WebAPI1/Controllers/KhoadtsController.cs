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
    public class KhoadtsController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public KhoadtsController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/Khoadts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khoadt>>> GetKhoadts()
        {
            return await _context.Khoadts.ToListAsync();
        }

        // GET: api/Khoadts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khoadt>> GetKhoadt(int id)
        {
            var khoadt = await _context.Khoadts.FindAsync(id);

            if (khoadt == null)
            {
                return NotFound();
            }

            return khoadt;
        }

        // PUT: api/Khoadts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoadt(int id, Khoadt khoadt)
        {
            if (id != khoadt.MaKhoaDt)
            {
                return BadRequest();
            }

            _context.Entry(khoadt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoadtExists(id))
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

        // POST: api/Khoadts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Khoadt>> PostKhoadt(Khoadt khoadt)
        {
            _context.Khoadts.Add(khoadt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhoadt", new { id = khoadt.MaKhoaDt }, khoadt);
        }

        // DELETE: api/Khoadts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoadt(int id)
        {
            var khoadt = await _context.Khoadts.FindAsync(id);
            if (khoadt == null)
            {
                return NotFound();
            }

            _context.Khoadts.Remove(khoadt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoadtExists(int id)
        {
            return _context.Khoadts.Any(e => e.MaKhoaDt == id);
        }
    }
}
