using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apexapp.Models;

namespace apexapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamoAtividadesController : ControllerBase
    {
        private readonly ApexAppContext _context;

        public RamoAtividadesController(ApexAppContext context)
        {
            _context = context;
        }

        // GET: api/RamoAtividades
        [HttpGet]
        public IEnumerable<RamoAtividade> GetRamoAtividades()
        {
            return _context.RamoAtividades;
        }

        // GET: api/RamoAtividades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRamoAtividade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ramoAtividade = await _context.RamoAtividades.FindAsync(id);

            if (ramoAtividade == null)
            {
                return NotFound();
            }

            return Ok(ramoAtividade);
        }

        // PUT: api/RamoAtividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRamoAtividade([FromRoute] int id, [FromBody] RamoAtividade ramoAtividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ramoAtividade.Id)
            {
                return BadRequest();
            }

            _context.Entry(ramoAtividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RamoAtividadeExists(id))
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

        // POST: api/RamoAtividades
        [HttpPost]
        public async Task<IActionResult> PostRamoAtividade([FromBody] RamoAtividade ramoAtividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RamoAtividades.Add(ramoAtividade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRamoAtividade", new { id = ramoAtividade.Id }, ramoAtividade);
        }

        // DELETE: api/RamoAtividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRamoAtividade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ramoAtividade = await _context.RamoAtividades.FindAsync(id);
            if (ramoAtividade == null)
            {
                return NotFound();
            }

            _context.RamoAtividades.Remove(ramoAtividade);
            await _context.SaveChangesAsync();

            return Ok(ramoAtividade);
        }

        private bool RamoAtividadeExists(int id)
        {
            return _context.RamoAtividades.Any(e => e.Id == id);
        }
    }
}