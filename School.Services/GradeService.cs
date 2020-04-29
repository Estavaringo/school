using School.Models.Database;
using School.Models.Request;
using School.Services.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services
{
    public class GradeService
    {
        private GradeRepository _gradeRepository;
        private ProfessorService _professorService;

        public GradeService(GradeRepository gradeRepository, ProfessorService professorService)
        {
            _gradeRepository = gradeRepository;
            _professorService = professorService;
        }

        public async Task<Grade> GetGradeAsync(int id)
        {
            return await _gradeRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Grade>> GetGradesAsync()
        {
            return await _gradeRepository.GetAsync();
        }

        public async Task<bool> CreateGradeAsync(GradeRequest gradeRequest)
        {

            Professor professor = _professorService.GetProfessorByCodigoFuncionario(gradeRequest.CodigoFuncionario);

            if (professor == null)
            {
                return false;
            }

            var grade = new Grade()
            {
                CodigoGrade = gradeRequest.CodigoGrade,
                NomeTurma = gradeRequest.Turma,
                NomeDisciplina = gradeRequest.Disciplina,
                NomeCurso = gradeRequest.Curso,
                ProfessorCpf = professor.Cpf
            };

            return await _gradeRepository.CreateAsync(grade);
        }

        public async Task<Grade> RemoveGradeAsync(int id)
        {
            return await _gradeRepository.RemoveAsync(id);
        }
    }
}
