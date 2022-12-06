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
    public class KhoasController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public KhoasController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/Khoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khoa>>> GetKhoas()
        {
            return await _context.Khoas.ToListAsync();
        }

        // GET: api/Khoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khoa>> GetKhoa(int id)
        {
            var khoa = await _context.Khoas.FindAsync(id);

            if (khoa == null)
            {
                return NotFound();
            }

            return khoa;
        }

        // PUT: api/Khoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoa(int id, Khoa khoa)
        {
            if (id != khoa.MaKhoa)
            {
                return BadRequest();
            }

            _context.Entry(khoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaExists(id))
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

        // POST: api/Khoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Khoa>> PostKhoa(Khoa khoa)
        {
            _context.Khoas.Add(khoa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhoa", new { id = khoa.MaKhoa }, khoa);
        }

        // DELETE: api/Khoas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoa(int id)
        {
            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }

            _context.Khoas.Remove(khoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaExists(int id)
        {
            return _context.Khoas.Any(e => e.MaKhoa == id);
        }
    }
}
