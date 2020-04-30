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
    public class GradeController : ControllerBase
    {
        private readonly GradeService _gradeService;

        public GradeController(GradeService gradeService)
        {
            _gradeService = gradeService;
        }


        // GET: api/Grade?codGrade=5
        [HttpGet]
        public async Task<ActionResult<GradeResponse>> GetGrade(int codGrade)
        {
            var grade = await _gradeService.GetGradeAsync(codGrade);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        // POST: api/Grade
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(GradeRequest grade)
        {

            if (await _gradeService.CreateGradeAsync(grade))
            {
                return CreatedAtAction("GetGrade", new { id = grade.CodigoGrade }, grade);
            }

            return StatusCode(500);
        }

        // DELETE: api/Grade?codGrade=5
        [HttpDelete]
        public async Task<ActionResult<Grade>> DeleteGrade(int codGrade)
        {

            var grade = await _gradeService.RemoveGradeAsync(codGrade);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }


    }
}
