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
    public class DetallePadecimientosController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public DetallePadecimientosController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/DetallePadecimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePadecimiento>>> GetDetallePadecimientos()
        {
            return await _context.DetallePadecimientos.ToListAsync();
        }

        // GET: api/DetallePadecimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePadecimiento>> GetDetallePadecimiento(int id)
        {
            var detallePadecimiento = await _context.DetallePadecimientos.FindAsync(id);

            if (detallePadecimiento == null)
            {
                return NotFound();
            }

            return detallePadecimiento;
        }

        // PUT: api/DetallePadecimientos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePadecimiento(int id, DetallePadecimiento detallePadecimiento)
        {
            if (id != detallePadecimiento.IddetallePadecimiento)
            {
                return BadRequest();
            }

            _context.Entry(detallePadecimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePadecimientoExists(id))
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

        // POST: api/DetallePadecimientos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallePadecimiento>> PostDetallePadecimiento(DetallePadecimiento detallePadecimiento)
        {
            _context.DetallePadecimientos.Add(detallePadecimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallePadecimiento", new { id = detallePadecimiento.IddetallePadecimiento }, detallePadecimiento);
        }

        // DELETE: api/DetallePadecimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePadecimiento(int id)
        {
            var detallePadecimiento = await _context.DetallePadecimientos.FindAsync(id);
            if (detallePadecimiento == null)
            {
                return NotFound();
            }

            _context.DetallePadecimientos.Remove(detallePadecimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallePadecimientoExists(int id)
        {
            return _context.DetallePadecimientos.Any(e => e.IddetallePadecimiento == id);
        }
    }
}
