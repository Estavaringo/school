using School.Models.Database;
using School.Models.Request;
using School.Services.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services
{
    public class ProfessorService
    {
        private ProfessorRepository _professorRepository;

        public ProfessorService(ProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<Professor> GetProfessorAsync(string cpf)
        {
            return await _professorRepository.GetAsync(cpf);
        }

        public async Task<IEnumerable<Professor>> GetProfessorsAsync()
        {
            return await _professorRepository.GetAsync();
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
