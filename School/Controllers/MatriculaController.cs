using Microsoft.AspNetCore.Mvc;
using School.Models.Database;
using School.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IDataRepository<Matricula> _matriculaRepository;

        public MatriculaController(IDataRepository<Matricula> matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        // GET: api/Matricula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatricula()
        {
            IEnumerable<Matricula> matriculas = await _matriculaRepository.GetAsync();
            return Ok(matriculas);
        }

        // GET: api/Matricula/4049732684/1234587
        [HttpGet("{alunoCpf}/{codigoGrade}")]
        public async Task<ActionResult<Matricula>> GetMatricula(string alunoCpf, int codigoGrade)
        {
            var matricula = await _matriculaRepository.GetAsync(alunoCpf, codigoGrade);

            if (matricula == null)
            {
                return NotFound();
            }

            return matricula;
        }

        // POST: api/Matricula
        [HttpPost]
        public async Task<ActionResult<Matricula>> PostMatricula(Matricula matricula)
        {

            if (await _matriculaRepository.CreateAsync(matricula))
            {
                return CreatedAtAction("GetMatricula", new { alunoCpf = matricula.FkAlunoCpf, codigoGrade = matricula.FkGradeCodigoGrade }, matricula);
            }

            return Conflict();
        }

        // DELETE: api/Matricula/4049732684/1234587
        [HttpDelete("{alunoCpf}/{codigoGrade}")]
        public async Task<ActionResult<Matricula>> DeleteMatricula(string alunoCpf, int codigoGrade)
        {

            var matriculaDeleted = await _matriculaRepository.RemoveAsync(alunoCpf, codigoGrade);

            if (matriculaDeleted == null)
            {
                return NotFound();
            }

            return matriculaDeleted;
        }

        // DELETE: api/Matricula
        [HttpDelete()]
        public async Task<ActionResult<Matricula>> DeleteMatricula(Matricula matricula)
        {

            var matriculaDeleted = await _matriculaRepository.RemoveAsync(matricula.FkAlunoCpf, matricula.FkGradeCodigoGrade);

            if (matriculaDeleted == null)
            {
                return NotFound();
            }

            return matriculaDeleted;
        }
    }
}
