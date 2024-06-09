using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAviacionCivil.Models;

namespace SistemaAviacionCivil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaVueloesController : ControllerBase
    {
        private readonly PruebaContext _context;

        public ProgramaVueloesController(PruebaContext context)
        {
            _context = context;
        }

        // GET: api/ProgramaVueloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramaVuelo>>> GetProgramaVuelos()
        {
            return await _context.ProgramaVuelos.ToListAsync();
        }

        // GET: api/ProgramaVueloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramaVuelo>> GetProgramaVuelo(int id)
        {
            var programaVuelo = await _context.ProgramaVuelos.FindAsync(id);

            if (programaVuelo == null)
            {
                return NotFound();
            }

            return programaVuelo;
        }

        // PUT: api/ProgramaVueloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramaVuelo(int id, ProgramaVuelo programaVuelo)
        {
            if (id != programaVuelo.IdVuelo)
            {
                return BadRequest();
            }

            _context.Entry(programaVuelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramaVueloExists(id))
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

        // POST: api/ProgramaVueloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgramaVuelo>> PostProgramaVuelo(ProgramaVuelo programaVuelo)
        {
            _context.ProgramaVuelos.Add(programaVuelo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProgramaVueloExists(programaVuelo.IdVuelo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProgramaVuelo", new { id = programaVuelo.IdVuelo }, programaVuelo);
        }

        // DELETE: api/ProgramaVueloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramaVuelo(int id)
        {
            var programaVuelo = await _context.ProgramaVuelos.FindAsync(id);
            if (programaVuelo == null)
            {
                return NotFound();
            }

            _context.ProgramaVuelos.Remove(programaVuelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramaVueloExists(int id)
        {
            return _context.ProgramaVuelos.Any(e => e.IdVuelo == id);
        }
    }
}
