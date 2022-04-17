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
    public class CitumsController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public CitumsController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/Citums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citum>>> GetCita()
        {
            return await _context.Cita.ToListAsync();
        }

        // GET: api/Citums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Citum>> GetCitum(int id)
        {
            var citum = await _context.Cita.FindAsync(id);

            if (citum == null)
            {
                return NotFound();
            }

            return citum;
        }

        // PUT: api/Citums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitum(int id, Citum citum)
        {
            if (id != citum.Idcita)
            {
                return BadRequest();
            }

            _context.Entry(citum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitumExists(id))
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

        // POST: api/Citums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Citum>> PostCitum(Citum citum)
        {
            _context.Cita.Add(citum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitum", new { id = citum.Idcita }, citum);
        }

        // DELETE: api/Citums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCitum(int id)
        {
            var citum = await _context.Cita.FindAsync(id);
            if (citum == null)
            {
                return NotFound();
            }

            _context.Cita.Remove(citum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitumExists(int id)
        {
            return _context.Cita.Any(e => e.Idcita == id);
        }
    }
}
