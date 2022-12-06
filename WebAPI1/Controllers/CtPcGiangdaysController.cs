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
    public class CtPcGiangdaysController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public CtPcGiangdaysController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/CtPcGiangdays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtPcGiangday>>> GetCtPcGiangdays()
        {
            return await _context.CtPcGiangdays.ToListAsync();
        }

        // GET: api/CtPcGiangdays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CtPcGiangday>> GetCtPcGiangday(int id)
        {
            var ctPcGiangday = await _context.CtPcGiangdays.FindAsync(id);

            if (ctPcGiangday == null)
            {
                return NotFound();
            }

            return ctPcGiangday;
        }

        // PUT: api/CtPcGiangdays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtPcGiangday(int id, CtPcGiangday ctPcGiangday)
        {
            if (id != ctPcGiangday.MaCtpcgd)
            {
                return BadRequest();
            }

            _context.Entry(ctPcGiangday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtPcGiangdayExists(id))
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

        // POST: api/CtPcGiangdays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CtPcGiangday>> PostCtPcGiangday(CtPcGiangday ctPcGiangday)
        {
            _context.CtPcGiangdays.Add(ctPcGiangday);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCtPcGiangday", new { id = ctPcGiangday.MaCtpcgd }, ctPcGiangday);
        }

        // DELETE: api/CtPcGiangdays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtPcGiangday(int id)
        {
            var ctPcGiangday = await _context.CtPcGiangdays.FindAsync(id);
            if (ctPcGiangday == null)
            {
                return NotFound();
            }

            _context.CtPcGiangdays.Remove(ctPcGiangday);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CtPcGiangdayExists(int id)
        {
            return _context.CtPcGiangdays.Any(e => e.MaCtpcgd == id);
        }
    }
}
