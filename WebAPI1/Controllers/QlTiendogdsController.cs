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
    public class QlTiendogdsController : ControllerBase
    {
        private readonly QuanLyGiaoVuContext _context;

        public QlTiendogdsController(QuanLyGiaoVuContext context)
        {
            _context = context;
        }

        // GET: api/QlTiendogds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QlTiendogd>>> GetQlTiendogds()
        {
            return await _context.QlTiendogds.ToListAsync();
        }

        // GET: api/QlTiendogds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QlTiendogd>> GetQlTiendogd(int id)
        {
            var qlTiendogd = await _context.QlTiendogds.FindAsync(id);

            if (qlTiendogd == null)
            {
                return NotFound();
            }

            return qlTiendogd;
        }

        // PUT: api/QlTiendogds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQlTiendogd(int id, QlTiendogd qlTiendogd)
        {
            if (id != qlTiendogd.MatienDo)
            {
                return BadRequest();
            }

            _context.Entry(qlTiendogd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QlTiendogdExists(id))
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

        // POST: api/QlTiendogds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QlTiendogd>> PostQlTiendogd(QlTiendogd qlTiendogd)
        {
            _context.QlTiendogds.Add(qlTiendogd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQlTiendogd", new { id = qlTiendogd.MatienDo }, qlTiendogd);
        }

        // DELETE: api/QlTiendogds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQlTiendogd(int id)
        {
            var qlTiendogd = await _context.QlTiendogds.FindAsync(id);
            if (qlTiendogd == null)
            {
                return NotFound();
            }

            _context.QlTiendogds.Remove(qlTiendogd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QlTiendogdExists(int id)
        {
            return _context.QlTiendogds.Any(e => e.MatienDo == id);
        }
    }
}
