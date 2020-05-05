using School.Helpers;
using School.Models.Database;
using School.Models.Request;
using School.Models.Response;
using School.Services.Repository;
using System.Threading.Tasks;

namespace School.Services
{
    public class ProfessorService
    {
        private readonly ProfessorRepository _professorRepository;
        private readonly SubgradeService _subgradeService;

        public ProfessorService(ProfessorRepository professorRepository, SubgradeService subgradeService)
        {
            _professorRepository = professorRepository;
            _subgradeService = subgradeService;
        }

        public async Task<ProfessorResponse> GetProfessorAsync(string cpf)
        {
            var professor = await _professorRepository.GetProfessorWithGradeAsync(cpf);
            double totalAlunos = 0;
            double totalGrades = 0;
            foreach (var grade in professor.Grades)
            {
                foreach (var subgrade in grade.Subgrades)
                {
                    if (subgrade.Matriculas.Count > 0)
                    {
                        totalGrades += 1;
                        totalAlunos += subgrade.Matriculas.Count;
                    }
                }
            }

            var coefficient = (totalAlunos / Constants.MAX_STUDENTS * totalGrades);

            var salary = coefficient * Constants.BONUS_BASE + Constants.SALARY;

            return new ProfessorResponse(professor.CodigoFuncionario, professor.Nome, professor.Cpf, professor.Email, (int) totalGrades, (int) totalAlunos, salary);

        }

        public async Task<bool> CreateProfessorAsync(ProfessorRequest professorRequest)
        {
            var professor = new Professor(professorRequest.Cpf, professorRequest.Email, professorRequest.Login, professorRequest.Nome, professorRequest.Codigo, professorRequest.Senha);

            return await _professorRepository.CreateAsync(professor);
        }

        public async Task<Professor> RemoveProfessorAsync(string cpf)
        {
            return await _professorRepository.RemoveAsync(cpf);
        }
        public Professor GetProfessorByCodigoFuncionario(int codigoFuncionario)
        {
            return _professorRepository.GetProfessorByCodigoFuncionario(codigoFuncionario);
        }
    }
}
