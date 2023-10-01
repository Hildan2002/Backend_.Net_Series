using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCiot_Fix.Db;
using MsCiot_Fix.Models;

namespace MsCiot_Fix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesinModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MesinModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MesinModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MesinModel>>> GetMesinModel()
        {
          if (_context.MesinModel == null)
          {
              return NotFound();
          }
            return await _context.MesinModel.ToListAsync();
        }

        // GET: api/MesinModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MesinModel>> GetMesinModel(int id)
        {
          if (_context.MesinModel == null)
          {
              return NotFound();
          }
            var mesinModel = await _context.MesinModel.FindAsync(id);

            if (mesinModel == null)
            {
                return NotFound();
            }

            return mesinModel;
        }

        // PUT: api/MesinModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesinModel(int id, MesinModel mesinModel)
        {
            if (id != mesinModel.IdMesin)
            {
                return BadRequest();
            }

            _context.Entry(mesinModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesinModelExists(id))
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

        // POST: api/MesinModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MesinModel>> PostMesinModel(MesinModel mesinModel)
        {
          if (_context.MesinModel == null)
          {
              return Problem("Entity set 'ApplicationDbContext.MesinModel'  is null.");
          }
            _context.MesinModel.Add(mesinModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesinModel", new { id = mesinModel.IdMesin }, mesinModel);
        }

        // DELETE: api/MesinModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesinModel(int id)
        {
            if (_context.MesinModel == null)
            {
                return NotFound();
            }
            var mesinModel = await _context.MesinModel.FindAsync(id);
            if (mesinModel == null)
            {
                return NotFound();
            }

            _context.MesinModel.Remove(mesinModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesinModelExists(int id)
        {
            return (_context.MesinModel?.Any(e => e.IdMesin == id)).GetValueOrDefault();
        }
    }
}
