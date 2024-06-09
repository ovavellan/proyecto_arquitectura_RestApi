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
    public class HangarsController : ControllerBase
    {
        private readonly PruebaContext _context;

        public HangarsController(PruebaContext context)
        {
            _context = context;
        }

        // GET: api/Hangars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hangar>>> GetHangars()
        {
            return await _context.Hangars.ToListAsync();
        }

        // GET: api/Hangars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hangar>> GetHangar(int id)
        {
            var hangar = await _context.Hangars.FindAsync(id);

            if (hangar == null)
            {
                return NotFound();
            }

            return hangar;
        }

        // PUT: api/Hangars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHangar(int id, Hangar hangar)
        {
            if (id != hangar.IdHangar)
            {
                return BadRequest();
            }

            _context.Entry(hangar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangarExists(id))
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

        // POST: api/Hangars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hangar>> PostHangar(Hangar hangar)
        {
            _context.Hangars.Add(hangar);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HangarExists(hangar.IdHangar))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHangar", new { id = hangar.IdHangar }, hangar);
        }

        // DELETE: api/Hangars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHangar(int id)
        {
            var hangar = await _context.Hangars.FindAsync(id);
            if (hangar == null)
            {
                return NotFound();
            }

            _context.Hangars.Remove(hangar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HangarExists(int id)
        {
            return _context.Hangars.Any(e => e.IdHangar == id);
        }
    }
}
