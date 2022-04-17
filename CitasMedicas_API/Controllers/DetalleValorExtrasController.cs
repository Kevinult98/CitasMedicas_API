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
    public class DetalleValorExtrasController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public DetalleValorExtrasController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/DetalleValorExtras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleValorExtra>>> GetDetalleValorExtras()
        {
            return await _context.DetalleValorExtras.ToListAsync();
        }

        // GET: api/DetalleValorExtras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleValorExtra>> GetDetalleValorExtra(int id)
        {
            var detalleValorExtra = await _context.DetalleValorExtras.FindAsync(id);

            if (detalleValorExtra == null)
            {
                return NotFound();
            }

            return detalleValorExtra;
        }

        // PUT: api/DetalleValorExtras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleValorExtra(int id, DetalleValorExtra detalleValorExtra)
        {
            if (id != detalleValorExtra.IddetalleValor)
            {
                return BadRequest();
            }

            _context.Entry(detalleValorExtra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleValorExtraExists(id))
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

        // POST: api/DetalleValorExtras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleValorExtra>> PostDetalleValorExtra(DetalleValorExtra detalleValorExtra)
        {
            _context.DetalleValorExtras.Add(detalleValorExtra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleValorExtra", new { id = detalleValorExtra.IddetalleValor }, detalleValorExtra);
        }

        // DELETE: api/DetalleValorExtras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleValorExtra(int id)
        {
            var detalleValorExtra = await _context.DetalleValorExtras.FindAsync(id);
            if (detalleValorExtra == null)
            {
                return NotFound();
            }

            _context.DetalleValorExtras.Remove(detalleValorExtra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleValorExtraExists(int id)
        {
            return _context.DetalleValorExtras.Any(e => e.IddetalleValor == id);
        }
    }
}
