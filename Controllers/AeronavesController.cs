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
    public class AeronavesController : ControllerBase
    {
        private readonly PruebaContext _context;

        public AeronavesController(PruebaContext context)
        {
            _context = context;
        }

        // GET: api/Aeronaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeronave>>> GetAeronaves()
        {
            return await _context.Aeronaves.ToListAsync();
        }

        // GET: api/Aeronaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeronave>> GetAeronave(int id)
        {
            var aeronave = await _context.Aeronaves.FindAsync(id);

            if (aeronave == null)
            {
                return NotFound();
            }

            return aeronave;
        }

        // PUT: api/Aeronaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeronave(int id, Aeronave aeronave)
        {
            if (id != aeronave.IdAvion)
            {
                return BadRequest();
            }

            _context.Entry(aeronave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeronaveExists(id))
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

        // POST: api/Aeronaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeronave>> PostAeronave(Aeronave aeronave)
        {
            _context.Aeronaves.Add(aeronave);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AeronaveExists(aeronave.IdAvion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAeronave", new { id = aeronave.IdAvion }, aeronave);
        }

        // DELETE: api/Aeronaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeronave(int id)
        {
            var aeronave = await _context.Aeronaves.FindAsync(id);
            if (aeronave == null)
            {
                return NotFound();
            }

            _context.Aeronaves.Remove(aeronave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeronaveExists(int id)
        {
            return _context.Aeronaves.Any(e => e.IdAvion == id);
        }
    }
}
