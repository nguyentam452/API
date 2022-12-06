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
    public class CtDtsController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public CtDtsController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/CtDts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtDt>>> GetCtDts()
        {
            return await _context.CtDts.ToListAsync();
        }

        // GET: api/CtDts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CtDt>> GetCtDt(int id)
        {
            var ctDt = await _context.CtDts.FindAsync(id);

            if (ctDt == null)
            {
                return NotFound();
            }

            return ctDt;
        }

        // PUT: api/CtDts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtDt(int id, CtDt ctDt)
        {
            if (id != ctDt.MaHocPhan)
            {
                return BadRequest();
            }

            _context.Entry(ctDt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtDtExists(id))
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

        // POST: api/CtDts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CtDt>> PostCtDt(CtDt ctDt)
        {
            _context.CtDts.Add(ctDt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCtDt", new { id = ctDt.MaHocPhan }, ctDt);
        }

        // DELETE: api/CtDts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtDt(int id)
        {
            var ctDt = await _context.CtDts.FindAsync(id);
            if (ctDt == null)
            {
                return NotFound();
            }

            _context.CtDts.Remove(ctDt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CtDtExists(int id)
        {
            return _context.CtDts.Any(e => e.MaHocPhan == id);
        }
    }
}
