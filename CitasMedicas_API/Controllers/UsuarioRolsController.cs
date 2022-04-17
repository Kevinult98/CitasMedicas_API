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
    public class UsuarioRolsController : ControllerBase
    {
        private readonly CitasMedicasContext _context;

        public UsuarioRolsController(CitasMedicasContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioRols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRol>>> GetUsuarioRols()
        {
            return await _context.UsuarioRols.ToListAsync();
        }

        // GET: api/UsuarioRols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRol>> GetUsuarioRol(int id)
        {
            var usuarioRol = await _context.UsuarioRols.FindAsync(id);

            if (usuarioRol == null)
            {
                return NotFound();
            }

            return usuarioRol;
        }

        // PUT: api/UsuarioRols/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioRol(int id, UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.IdusuarioRol)
            {
                return BadRequest();
            }

            _context.Entry(usuarioRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioRolExists(id))
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

        // POST: api/UsuarioRols
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioRol>> PostUsuarioRol(UsuarioRol usuarioRol)
        {
            _context.UsuarioRols.Add(usuarioRol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioRol", new { id = usuarioRol.IdusuarioRol }, usuarioRol);
        }

        // DELETE: api/UsuarioRols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioRol(int id)
        {
            var usuarioRol = await _context.UsuarioRols.FindAsync(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            _context.UsuarioRols.Remove(usuarioRol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioRolExists(int id)
        {
            return _context.UsuarioRols.Any(e => e.IdusuarioRol == id);
        }
    }
}
