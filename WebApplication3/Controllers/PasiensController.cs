using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasiensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PasiensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pasiens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasien>>> GetPasien()
        {
          if (_context.Pasien == null)
          {
              return NotFound();
          }
            return await _context.Pasien.ToListAsync();
        }

        // GET: api/Pasiens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pasien>> GetPasien(int id)
        {
          if (_context.Pasien == null)
          {
              return NotFound();
          }
            var pasien = await _context.Pasien.FindAsync(id);

            if (pasien == null)
            {
                return NotFound();
            }

            return pasien;
        }

        // PUT: api/Pasiens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasien(int id, Pasien pasien)
        {
            if (id != pasien.PasienId)
            {
                return BadRequest();
            }

            _context.Entry(pasien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasienExists(id))
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

        // POST: api/Pasiens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pasien>> PostPasien(Pasien pasien)
        {
          if (_context.Pasien == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Pasien'  is null.");
          }
            _context.Pasien.Add(pasien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasien", new { id = pasien.PasienId }, pasien);
        }

        // DELETE: api/Pasiens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasien(int id)
        {
            if (_context.Pasien == null)
            {
                return NotFound();
            }
            var pasien = await _context.Pasien.FindAsync(id);
            if (pasien == null)
            {
                return NotFound();
            }

            _context.Pasien.Remove(pasien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasienExists(int id)
        {
            return (_context.Pasien?.Any(e => e.PasienId == id)).GetValueOrDefault();
        }
    }
}
