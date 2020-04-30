using School.Models.Database;
using School.Models.Request;
using School.Models.Response;
using School.Services.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services
{
    public class GradeService
    {
        private readonly GradeRepository _gradeRepository;
        private readonly ProfessorService _professorService;
        private readonly AlunoService _alunoService;

        public GradeService(GradeRepository gradeRepository, ProfessorService professorService, AlunoService alunoService)
        {
            _gradeRepository = gradeRepository;
            _professorService = professorService;
            _alunoService = alunoService;
        }

        public async Task<GradeResponse> GetGradeAsync(int id)
        {
            GradeResponse gradeResponse = null;

            var grade = await _gradeRepository.GetGradeWithProfessorAndMatriculasAsync(id);

            if (grade != null)
            {
                var alunos = await _alunoService.GetAlunosByMatriculasAsync(grade.Matriculas);

                gradeResponse = new GradeResponse(grade, alunos);

            }

            return gradeResponse;

        }

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
            return await _gradeRepository.GetAsync();
        }

        public async Task<bool> CreateGradeAsync(GradeRequest gradeRequest)
        {

            var professor = _professorService.GetProfessorByCodigoFuncionario(gradeRequest.CodigoFuncionario);

            if (professor == null)
            {
                return false;
            }

            var grade = new Grade(gradeRequest.CodigoGrade, gradeRequest.Turma, gradeRequest.Disciplina, gradeRequest.Curso, professor.Cpf);

            return await _gradeRepository.CreateAsync(grade);
        }

        public async Task<Grade> RemoveGradeAsync(int id)
        {
            return await _gradeRepository.RemoveAsync(id);
        }
    }
}
