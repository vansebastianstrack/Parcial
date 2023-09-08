﻿using System;
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
    public class AutoesController : ControllerBase
    {
        private readonly TallerMecanicaContext _context;

        public AutoesController(TallerMecanicaContext context)
        {
            _context = context;
        }

        // GET: api/Autoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auto>>> GetAutos()
        {
          if (_context.Autos == null)
          {
              return NotFound();
          }
            return await _context.Autos.ToListAsync();
        }

        // GET: api/Autoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auto>> GetAuto(int id)
        {
          if (_context.Autos == null)
          {
              return NotFound();
          }
            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
            {
                return NotFound();
            }

            return auto;
        }

        // PUT: api/Autoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuto(int id, Auto auto)
        {
            if (id != auto.IdAuto)
            {
                return BadRequest();
            }

            _context.Entry(auto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoExists(id))
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

        // POST: api/Autoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auto>> PostAuto(Auto auto)
        {
          if (_context.Autos == null)
          {
              return Problem("Entity set 'TallerMecanicaContext.Autos'  is null.");
          }
            _context.Autos.Add(auto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuto", new { id = auto.IdAuto }, auto);
        }

        // DELETE: api/Autoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuto(int id)
        {
            if (_context.Autos == null)
            {
                return NotFound();
            }
            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }

            _context.Autos.Remove(auto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoExists(int id)
        {
            return (_context.Autos?.Any(e => e.IdAuto == id)).GetValueOrDefault();
        }
    }
}
