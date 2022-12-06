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
    public class PhongsController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public PhongsController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/Phongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phong>>> GetPhongs()
        {
            return await _context.Phongs.ToListAsync();
        }

        // GET: api/Phongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phong>> GetPhong(int id)
        {
            var phong = await _context.Phongs.FindAsync(id);

            if (phong == null)
            {
                return NotFound();
            }

            return phong;
        }

        // PUT: api/Phongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhong(int id, Phong phong)
        {
            if (id != phong.MaPhong)
            {
                return BadRequest();
            }

            _context.Entry(phong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongExists(id))
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

        // POST: api/Phongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Phong>> PostPhong(Phong phong)
        {
            _context.Phongs.Add(phong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhong", new { id = phong.MaPhong }, phong);
        }

        // DELETE: api/Phongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhong(int id)
        {
            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }

            _context.Phongs.Remove(phong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhongExists(int id)
        {
            return _context.Phongs.Any(e => e.MaPhong == id);
        }
    }
}
