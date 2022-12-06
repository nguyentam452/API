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
    public class NganhsController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public NganhsController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/Nganhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nganh>>> GetNganhs()
        {
            return await _context.Nganhs.ToListAsync();
        }

        // GET: api/Nganhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nganh>> GetNganh(int id)
        {
            var nganh = await _context.Nganhs.FindAsync(id);

            if (nganh == null)
            {
                return NotFound();
            }

            return nganh;
        }

        // PUT: api/Nganhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNganh(int id, Nganh nganh)
        {
            if (id != nganh.MaNganh)
            {
                return BadRequest();
            }

            _context.Entry(nganh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NganhExists(id))
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

        // POST: api/Nganhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nganh>> PostNganh(Nganh nganh)
        {
            _context.Nganhs.Add(nganh);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNganh", new { id = nganh.MaNganh }, nganh);
        }

        // DELETE: api/Nganhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNganh(int id)
        {
            var nganh = await _context.Nganhs.FindAsync(id);
            if (nganh == null)
            {
                return NotFound();
            }

            _context.Nganhs.Remove(nganh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NganhExists(int id)
        {
            return _context.Nganhs.Any(e => e.MaNganh == id);
        }
    }
}
