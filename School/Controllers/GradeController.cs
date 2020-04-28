using Microsoft.AspNetCore.Mvc;
using School.Models.Database;
using School.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IDataRepository<Grade> _gradeRepository;

        public GradeController(IDataRepository<Grade> gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        // GET: api/Grade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrade()
        {
            IEnumerable<Grade> grades = await _gradeRepository.GetAsync();
            return Ok(grades);
        }

        // GET: api/Grade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _gradeRepository.GetAsync(id);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        // PUT: api/Grade/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.CodigoGrade)
            {
                return BadRequest();
            }


            if (await _gradeRepository.EditAsync(grade))
            {
                return NoContent();

            }

            return NotFound();

        }

        // POST: api/Grade
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {

            if (await _gradeRepository.CreateAsync(grade))
            {
                return CreatedAtAction("GetGrade", new { id = grade.CodigoGrade }, grade);
            }

            return Conflict();
        }

        // DELETE: api/Grade/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Grade>> DeleteGrade(int id)
        {

            var grade = await _gradeRepository.RemoveAsync(id);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }
    }
}
