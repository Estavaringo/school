using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly SchoolContext _context;

        public MatriculaController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Matricula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatricula()
        {
            return await _context.Matricula.ToListAsync();
        }

        // GET: api/Matricula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> GetMatricula(string id)
        {
            var matricula = await _context.Matricula.FindAsync(id);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        // PUT: api/Matricula/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatricula(string id, Matricula matricula)
        {
            if (id != matricula.FkAlunoCpf)
            {
                return BadRequest();
            }

            _context.Entry(matricula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatriculaExists(id))
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

        // POST: api/Matricula
        [HttpPost]
        public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MatriculaExists(matricula.FkAlunoCpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMatricula", new { id = matricula.FkAlunoCpf }, matricula);
        }

        // DELETE: api/Matricula/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Matricula>> DeleteMatricula(string id)
        {
            var matricula = await _context.Matricula.FindAsync(id);
            if (matricula == null)
            {
                return NotFound();
            }

            _context.Matricula.Remove(matricula);
            await _context.SaveChangesAsync();

            return matricula;
        }

        private bool MatriculaExists(string id)
        {
            return _context.Matricula.Any(e => e.FkAlunoCpf == id);
        }
    }
}
