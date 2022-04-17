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
    public class PadecimientoesController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public PadecimientoesController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/Padecimientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Padecimiento>>> GetPadecimientos()
        {
            return await _context.Padecimientos.ToListAsync();
        }

        // GET: api/Padecimientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Padecimiento>> GetPadecimiento(int id)
        {
            var padecimiento = await _context.Padecimientos.FindAsync(id);

            if (padecimiento == null)
            {
                return NotFound();
            }

            return padecimiento;
        }

        // PUT: api/Padecimientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPadecimiento(int id, Padecimiento padecimiento)
        {
            if (id != padecimiento.Idpadecimiento)
            {
                return BadRequest();
            }

            _context.Entry(padecimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PadecimientoExists(id))
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

        // POST: api/Padecimientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Padecimiento>> PostPadecimiento(Padecimiento padecimiento)
        {
            _context.Padecimientos.Add(padecimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPadecimiento", new { id = padecimiento.Idpadecimiento }, padecimiento);
        }

        // DELETE: api/Padecimientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePadecimiento(int id)
        {
            var padecimiento = await _context.Padecimientos.FindAsync(id);
            if (padecimiento == null)
            {
                return NotFound();
            }

            _context.Padecimientos.Remove(padecimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PadecimientoExists(int id)
        {
            return _context.Padecimientos.Any(e => e.Idpadecimiento == id);
        }
    }
}
