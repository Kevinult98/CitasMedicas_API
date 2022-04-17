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
    public class DoctorEspecialidadsController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public DoctorEspecialidadsController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/DoctorEspecialidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorEspecialidad>>> GetDoctorEspecialidads()
        {
            return await _context.DoctorEspecialidads.ToListAsync();
        }

        // GET: api/DoctorEspecialidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorEspecialidad>> GetDoctorEspecialidad(int id)
        {
            var doctorEspecialidad = await _context.DoctorEspecialidads.FindAsync(id);

            if (doctorEspecialidad == null)
            {
                return NotFound();
            }

            return doctorEspecialidad;
        }

        // PUT: api/DoctorEspecialidads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorEspecialidad(int id, DoctorEspecialidad doctorEspecialidad)
        {
            if (id != doctorEspecialidad.IddoctorEspecialidad)
            {
                return BadRequest();
            }

            _context.Entry(doctorEspecialidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorEspecialidadExists(id))
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

        // POST: api/DoctorEspecialidads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoctorEspecialidad>> PostDoctorEspecialidad(DoctorEspecialidad doctorEspecialidad)
        {
            _context.DoctorEspecialidads.Add(doctorEspecialidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorEspecialidad", new { id = doctorEspecialidad.IddoctorEspecialidad }, doctorEspecialidad);
        }

        // DELETE: api/DoctorEspecialidads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorEspecialidad(int id)
        {
            var doctorEspecialidad = await _context.DoctorEspecialidads.FindAsync(id);
            if (doctorEspecialidad == null)
            {
                return NotFound();
            }

            _context.DoctorEspecialidads.Remove(doctorEspecialidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorEspecialidadExists(int id)
        {
            return _context.DoctorEspecialidads.Any(e => e.IddoctorEspecialidad == id);
        }
    }
}
