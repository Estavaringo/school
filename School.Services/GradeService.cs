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
        private readonly MatriculaService _matriculaService;

        public GradeService(GradeRepository gradeRepository, ProfessorService professorService, AlunoService alunoService, MatriculaService matriculaService)
        {
            _gradeRepository = gradeRepository;
            _professorService = professorService;
            _alunoService = alunoService;
            _matriculaService = matriculaService;
        }

        public async Task<GradeResponse> GetGradeAsync(int codigoGrade)
        {
            GradeResponse gradeResponse = null;

            var grade = await _gradeRepository.GetGradeWithProfessorAndMatriculasAsync(codigoGrade);

            if (grade != null)
            {
                var matriculas = _matriculaService.GetMatriculasBySubgrades(grade.Subgrades);

                var alunos = await _alunoService.GetAlunosByMatriculasAsync(matriculas);

                gradeResponse = new GradeResponse(grade, alunos);
            }

            return gradeResponse;

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
