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
    public class HsGiangviensController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public HsGiangviensController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/HsGiangviens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HsGiangvien>>> GetHsGiangviens()
        {
            return await _context.HsGiangviens.ToListAsync();
        }

        // GET: api/HsGiangviens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HsGiangvien>> GetHsGiangvien(int id)
        {
            var hsGiangvien = await _context.HsGiangviens.FindAsync(id);

            if (hsGiangvien == null)
            {
                return NotFound();
            }

            return hsGiangvien;
        }

        // PUT: api/HsGiangviens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHsGiangvien(int id, HsGiangvien hsGiangvien)
        {
            if (id != hsGiangvien.MaGv)
            {
                return BadRequest();
            }

            _context.Entry(hsGiangvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HsGiangvienExists(id))
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

        // POST: api/HsGiangviens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HsGiangvien>> PostHsGiangvien(HsGiangvien hsGiangvien)
        {
            _context.HsGiangviens.Add(hsGiangvien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHsGiangvien", new { id = hsGiangvien.MaGv }, hsGiangvien);
        }

        // DELETE: api/HsGiangviens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHsGiangvien(int id)
        {
            var hsGiangvien = await _context.HsGiangviens.FindAsync(id);
            if (hsGiangvien == null)
            {
                return NotFound();
            }

            _context.HsGiangviens.Remove(hsGiangvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HsGiangvienExists(int id)
        {
            return _context.HsGiangviens.Any(e => e.MaGv == id);
        }
    }
}
