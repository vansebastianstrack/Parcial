using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller_mecanica.Models;

namespace Taller_mecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoesController : ControllerBase
    {
        private readonly TallerMecanicaContext _context;

        public MecanicoesController(TallerMecanicaContext context)
        {
            _context = context;
        }

        // GET: api/Mecanicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mecanico>>> GetMecanicos()
        {
          if (_context.Mecanicos == null)
          {
              return NotFound();
          }
            return await _context.Mecanicos.ToListAsync();
        }

        // GET: api/Mecanicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecanico>> GetMecanico(int id)
        {
          if (_context.Mecanicos == null)
          {
              return NotFound();
          }
            var mecanico = await _context.Mecanicos.FindAsync(id);

            if (mecanico == null)
            {
                return NotFound();
            }

            return mecanico;
        }

        // PUT: api/Mecanicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecanico(int id, Mecanico mecanico)
        {
            if (id != mecanico.IdMecanico)
            {
                return BadRequest();
            }

            _context.Entry(mecanico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MecanicoExists(id))
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

        // POST: api/Mecanicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mecanico>> PostMecanico(Mecanico mecanico)
        {
          if (_context.Mecanicos == null)
          {
              return Problem("Entity set 'TallerMecanicaContext.Mecanicos'  is null.");
          }
            _context.Mecanicos.Add(mecanico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMecanico", new { id = mecanico.IdMecanico }, mecanico);
        }

        // DELETE: api/Mecanicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMecanico(int id)
        {
            if (_context.Mecanicos == null)
            {
                return NotFound();
            }
            var mecanico = await _context.Mecanicos.FindAsync(id);
            if (mecanico == null)
            {
                return NotFound();
            }

            _context.Mecanicos.Remove(mecanico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MecanicoExists(int id)
        {
            return (_context.Mecanicos?.Any(e => e.IdMecanico == id)).GetValueOrDefault();
        }
    }
}
