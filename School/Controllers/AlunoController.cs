using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Services;

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

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAluno()
        {
            IEnumerable<Aluno> alunos = await _alunoService.GetAsync();
            return Ok(alunos);
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(string id)
        {
            var aluno = await _alunoService.GetAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(string id, Aluno aluno)
        {
            if (id != aluno.Cpf)
            {
                return BadRequest();
            }


            if (await _alunoService.EditAsync(id, aluno))
            {
                return NoContent();

            }

            return NotFound();

        }

        // POST: api/Aluno
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {

            if (await _alunoService.CreateAsync(aluno))
            {
                return CreatedAtAction("GetAluno", new { id = aluno.Cpf }, aluno);
            }

            return Conflict();
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(string id)
        {

            var aluno = await _alunoService.RemoveAsync(id);

            if(aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }


    }
}
