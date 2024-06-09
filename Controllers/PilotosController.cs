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
    [Authorize]
    [ApiController]
    public class PilotosController : ControllerBase
    {
        private readonly PruebaContext _context;

        public PilotosController(PruebaContext context)
        {
            _context = context;
        }

        // GET: api/Pilotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piloto>>> GetPilotos()
        {
            return await _context.Pilotos.ToListAsync();
        }

        // GET: api/Pilotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Piloto>> GetPiloto(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);

            if (piloto == null)
            {
                return NotFound();
            }

            return piloto;
        }

        // PUT: api/Pilotoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPiloto(int id, Piloto piloto)
        {
            if (id != piloto.IdPiloto)
            {
                return BadRequest();
            }

            _context.Entry(piloto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PilotoExists(id))
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

        // POST: api/Pilotoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Piloto>> PostPiloto(Piloto piloto)
        {
            _context.Pilotos.Add(piloto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PilotoExists(piloto.IdPiloto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPiloto", new { id = piloto.IdPiloto }, piloto);
        }

        // DELETE: api/Pilotoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePiloto(int id)
        {
            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto == null)
            {
                return NotFound();
            }

            _context.Pilotos.Remove(piloto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PilotoExists(int id)
        {
            return _context.Pilotos.Any(e => e.IdPiloto == id);
        }
    }
}
