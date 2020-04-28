using Microsoft.AspNetCore.Mvc;
using School.Models.Database;
using School.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IDataRepository<Aluno> _alunoRepository;

        public AlunoController(IDataRepository<Aluno> alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {
            IEnumerable<Aluno> alunos = await _alunoRepository.GetAsync();
            return Ok(alunos);
        }

        // GET: api/Aluno/5
        [HttpGet("{cpf}")]
        public async Task<ActionResult<Aluno>> GetAluno(string cpf)
        {
            var aluno = await _alunoRepository.GetAsync(cpf);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/Aluno/5
        [HttpPut("{cpf}")]
        public async Task<IActionResult> PutAluno(string cpf, Aluno aluno)
        {
            if (cpf != aluno.Cpf)
            {
                return BadRequest();
            }


            if (await _alunoRepository.EditAsync(aluno))
            {
                return NoContent();

            }

            return NotFound();

        }

        // POST: api/Aluno
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {

            if (await _alunoRepository.CreateAsync(aluno))
            {
                return CreatedAtAction("GetAluno", new { id = aluno.Cpf }, aluno);
            }

            return Conflict();
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{cpf}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(string cpf)
        {

            var aluno = await _alunoRepository.RemoveAsync(cpf);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }


    }
}
