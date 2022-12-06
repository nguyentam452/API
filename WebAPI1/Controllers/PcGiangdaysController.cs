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
    public class PcGiangdaysController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public PcGiangdaysController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/PcGiangdays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PcGiangday>>> GetPcGiangdays()
        {
            return await _context.PcGiangdays.ToListAsync();
        }

        // GET: api/PcGiangdays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PcGiangday>> GetPcGiangday(int id)
        {
            var pcGiangday = await _context.PcGiangdays.FindAsync(id);

            if (pcGiangday == null)
            {
                return NotFound();
            }

            return pcGiangday;
        }

        // PUT: api/PcGiangdays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPcGiangday(int id, PcGiangday pcGiangday)
        {
            if (id != pcGiangday.MaPcgd)
            {
                return BadRequest();
            }

            _context.Entry(pcGiangday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PcGiangdayExists(id))
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

        // POST: api/PcGiangdays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PcGiangday>> PostPcGiangday(PcGiangday pcGiangday)
        {
            _context.PcGiangdays.Add(pcGiangday);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPcGiangday", new { id = pcGiangday.MaPcgd }, pcGiangday);
        }

        // DELETE: api/PcGiangdays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePcGiangday(int id)
        {
            var pcGiangday = await _context.PcGiangdays.FindAsync(id);
            if (pcGiangday == null)
            {
                return NotFound();
            }

            _context.PcGiangdays.Remove(pcGiangday);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PcGiangdayExists(int id)
        {
            return _context.PcGiangdays.Any(e => e.MaPcgd == id);
        }
    }
}
