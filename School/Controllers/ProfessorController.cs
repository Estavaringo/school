using Microsoft.AspNetCore.Mvc;
using School.Models.Database;
using School.Models.Request;
using School.Models.Response;
using School.Services;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorService _professorService;

        public ProfessorController(ProfessorService professorService)
        {
            _professorService = professorService;
        }


        // GET: school/Professor?cpf=12345678910
        [HttpGet]
        public async Task<ActionResult<ProfessorResponse>> GetProfessor(string cpf)
        {
            var professor = await _professorService.GetProfessorAsync(cpf);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }

        // POST: school/professor
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(ProfessorRequest professor)
        {

            if (await _professorService.CreateProfessorAsync(professor))
            {
                return CreatedAtAction("GetProfessor", new { cpf = professor.Cpf }, professor);
            }

            return StatusCode(500);
        }

        // DELETE: school/professor?cpf=12345678910
        [HttpDelete]
        public async Task<ActionResult<Professor>> DeleteProfessor(string cpf)
        {

            var professor = await _professorService.RemoveProfessorAsync(cpf);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }


    }
}
