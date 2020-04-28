using Microsoft.AspNetCore.Mvc;
using School.Models.Database;
using School.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IDataRepository<Professor> _professorRepository;

        public ProfessorController(IDataRepository<Professor> professorRepository)
        {
            _professorRepository = professorRepository;
        }

        // GET: api/Professor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessor()
        {
            IEnumerable<Professor> professors = await _professorRepository.GetAsync();
            return Ok(professors);
        }

        // GET: api/Professor/5
        [HttpGet("{cpf}")]
        public async Task<ActionResult<Professor>> GetProfessor(string cpf)
        {
            var professor = await _professorRepository.GetAsync(cpf);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }

        // PUT: api/Professor/5
        [HttpPut("{cpf}")]
        public async Task<IActionResult> PutProfessor(string cpf, Professor professor)
        {
            if (cpf != professor.Cpf)
            {
                return BadRequest();
            }

            if (await _professorRepository.EditAsync(professor))
            {
                return NoContent();

            }

            return NotFound();

        }

        // POST: api/Professor
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {

            if (await _professorRepository.CreateAsync(professor))
            {
                return CreatedAtAction("GetProfessor", new { id = professor.Cpf }, professor);
            }

            return Conflict();
        }

        // DELETE: api/Professor/5
        [HttpDelete("{cpf}")]
        public async Task<ActionResult<Professor>> DeleteProfessor(string cpf)
        {

            var professor = await _professorRepository.RemoveAsync(cpf);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }
    }
}
