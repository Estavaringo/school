using Microsoft.AspNetCore.Mvc;
using School.Models.Database;
using School.Models.Request;
using School.Services;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        // GET: school/aluno?cpf=12345678910
        [HttpGet]
        public async Task<ActionResult<Aluno>> GetAluno(string cpf)
        {
            var aluno = await _alunoService.GetAlunoAsync(cpf);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // POST: school/aluno
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(AlunoRequest aluno)
        {

            if (await _alunoService.CreateAlunoAsync(aluno))
            {
                return CreatedAtAction("GetAluno", new { cpf = aluno.Cpf }, aluno);
            }

            return StatusCode(500);
        }

        // DELETE: school/aluno?cpf=12345678910
        [HttpDelete]
        public async Task<ActionResult<Aluno>> DeleteAluno(string cpf)
        {

            var aluno = await _alunoService.RemoveAlunoAsync(cpf);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }


    }
}
