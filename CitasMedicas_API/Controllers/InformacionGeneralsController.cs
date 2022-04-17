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
    public class InformacionGeneralsController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public InformacionGeneralsController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/InformacionGenerals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformacionGeneral>>> GetInformacionGenerals()
        {
            return await _context.InformacionGenerals.ToListAsync();
        }

        // GET: api/InformacionGenerals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InformacionGeneral>> GetInformacionGeneral(string id)
        {
            var informacionGeneral = await _context.InformacionGenerals.FindAsync(id);

            if (informacionGeneral == null)
            {
                return NotFound();
            }

            return informacionGeneral;
        }

        // PUT: api/InformacionGenerals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformacionGeneral(string id, InformacionGeneral informacionGeneral)
        {
            if (id != informacionGeneral.Idinformacion)
            {
                return BadRequest();
            }

            _context.Entry(informacionGeneral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformacionGeneralExists(id))
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

        // POST: api/InformacionGenerals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InformacionGeneral>> PostInformacionGeneral(InformacionGeneral informacionGeneral)
        {
            _context.InformacionGenerals.Add(informacionGeneral);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InformacionGeneralExists(informacionGeneral.Idinformacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInformacionGeneral", new { id = informacionGeneral.Idinformacion }, informacionGeneral);
        }

        // DELETE: api/InformacionGenerals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInformacionGeneral(string id)
        {
            var informacionGeneral = await _context.InformacionGenerals.FindAsync(id);
            if (informacionGeneral == null)
            {
                return NotFound();
            }

            _context.InformacionGenerals.Remove(informacionGeneral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InformacionGeneralExists(string id)
        {
            return _context.InformacionGenerals.Any(e => e.Idinformacion == id);
        }
    }
}
