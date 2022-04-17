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
    public class ValorExtrasController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public ValorExtrasController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/ValorExtras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValorExtra>>> GetValorExtras()
        {
            return await _context.ValorExtras.ToListAsync();
        }

        // GET: api/ValorExtras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValorExtra>> GetValorExtra(int id)
        {
            var valorExtra = await _context.ValorExtras.FindAsync(id);

            if (valorExtra == null)
            {
                return NotFound();
            }

            return valorExtra;
        }

        // PUT: api/ValorExtras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValorExtra(int id, ValorExtra valorExtra)
        {
            if (id != valorExtra.IdvalorExtra)
            {
                return BadRequest();
            }

            _context.Entry(valorExtra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValorExtraExists(id))
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

        // POST: api/ValorExtras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ValorExtra>> PostValorExtra(ValorExtra valorExtra)
        {
            _context.ValorExtras.Add(valorExtra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValorExtra", new { id = valorExtra.IdvalorExtra }, valorExtra);
        }

        // DELETE: api/ValorExtras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValorExtra(int id)
        {
            var valorExtra = await _context.ValorExtras.FindAsync(id);
            if (valorExtra == null)
            {
                return NotFound();
            }

            _context.ValorExtras.Remove(valorExtra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValorExtraExists(int id)
        {
            return _context.ValorExtras.Any(e => e.IdvalorExtra == id);
        }
    }
}
