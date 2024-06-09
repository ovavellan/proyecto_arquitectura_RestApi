using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAviacionCivil.Models;

namespace SistemaAviacionCivil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeropuertoesController : ControllerBase
    {
        private readonly PruebaContext _context;

        public AeropuertoesController(PruebaContext context)
        {
            _context = context;
        }

        // GET: api/Aeropuertoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeropuerto>>> GetAeropuertos()
        {
            return await _context.Aeropuertos.ToListAsync();
        }

        // GET: api/Aeropuertoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeropuerto>> GetAeropuerto(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);

            if (aeropuerto == null)
            {
                return NotFound();
            }

            return aeropuerto;
        }

        // PUT: api/Aeropuertoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeropuerto(int id, Aeropuerto aeropuerto)
        {
            if (id != aeropuerto.IdAeropuerto)
            {
                return BadRequest();
            }

            _context.Entry(aeropuerto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeropuertoExists(id))
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

        // POST: api/Aeropuertoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeropuerto>> PostAeropuerto(Aeropuerto aeropuerto)
        {
            _context.Aeropuertos.Add(aeropuerto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AeropuertoExists(aeropuerto.IdAeropuerto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAeropuerto", new { id = aeropuerto.IdAeropuerto }, aeropuerto);
        }

        // DELETE: api/Aeropuertoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeropuerto(int id)
        {
            var aeropuerto = await _context.Aeropuertos.FindAsync(id);
            if (aeropuerto == null)
            {
                return NotFound();
            }

            _context.Aeropuertos.Remove(aeropuerto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeropuertoExists(int id)
        {
            return _context.Aeropuertos.Any(e => e.IdAeropuerto == id);
        }
    }
}
