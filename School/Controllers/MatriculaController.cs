using Microsoft.AspNetCore.Mvc;
using School.Models.Database;
using School.Models.Request;
using School.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly MatriculaService _matriculaService;

        public MatriculaController(MatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        // GET: school/matricula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatricula()
        {
            IEnumerable<Matricula> matriculas = await _matriculaService.GetMatriculasAsync();
            return Ok(matriculas);
        }

        // POST: school/matricula
        [HttpPost]
        public async Task<ActionResult<Matricula>> PostMatricula(MatriculaRequest matricula)
        {

            if (await _matriculaService.CreateMatriculaAsync(matricula))
            {
                return StatusCode(201, matricula);
            }

            return StatusCode(500);
        }

        // DELETE: school/matricula
        [HttpDelete]
        public async Task<ActionResult<Matricula>> DeleteMatricula(MatriculaRequest matricula)
        {

            var matriculaDeleted = await _matriculaService.RemoveMatriculaAsync(matricula);

            if (matriculaDeleted == null)
            {
                return NotFound();
            }

            return matriculaDeleted;
        }
    }
}
