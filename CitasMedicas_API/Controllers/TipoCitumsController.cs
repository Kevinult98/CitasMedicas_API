using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitasMedicas_API.Models;

namespace CitasMedicas_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCitumsController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public TipoCitumsController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/TipoCitums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCitum>>> GetTipoCita()
        {
            return await _context.TipoCita.ToListAsync();
        }

        // GET: api/TipoCitums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCitum>> GetTipoCitum(int id)
        {
            var tipoCitum = await _context.TipoCita.FindAsync(id);

            if (tipoCitum == null)
            {
                return NotFound();
            }

            return tipoCitum;
        }

        // PUT: api/TipoCitums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCitum(int id, TipoCitum tipoCitum)
        {
            if (id != tipoCitum.IdtipoCita)
            {
                return BadRequest();
            }

            _context.Entry(tipoCitum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCitumExists(id))
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

        // POST: api/TipoCitums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCitum>> PostTipoCitum(TipoCitum tipoCitum)
        {
            _context.TipoCita.Add(tipoCitum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCitum", new { id = tipoCitum.IdtipoCita }, tipoCitum);
        }

        // DELETE: api/TipoCitums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCitum(int id)
        {
            var tipoCitum = await _context.TipoCita.FindAsync(id);
            if (tipoCitum == null)
            {
                return NotFound();
            }

            _context.TipoCita.Remove(tipoCitum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCitumExists(int id)
        {
            return _context.TipoCita.Any(e => e.IdtipoCita == id);
        }
    }
}
