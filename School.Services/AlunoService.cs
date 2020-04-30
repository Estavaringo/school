using School.Models.Database;
using School.Models.Request;
using School.Services.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services
{
    public class AlunoService
    {
        private readonly AlunoRepository _alunoRepository;

        public AlunoService(AlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Aluno> GetAlunoAsync(string cpf)
        {
            return await _alunoRepository.GetAsync(cpf);
        }

        public async Task<IEnumerable<Aluno>> GetAlunosAsync()
        {
            return await _alunoRepository.GetAsync();
        }

        public async Task<bool> CreateAlunoAsync(AlunoRequest alunoRequest)
        {
            var aluno = new Aluno(alunoRequest.Cpf, alunoRequest.Email, alunoRequest.Login, alunoRequest.Nome, alunoRequest.Ra, alunoRequest.Senha);

            return await _alunoRepository.CreateAsync(aluno);
        }

        public async Task<IList<Aluno>> GetAlunosByMatriculasAsync(ICollection<Matricula> matriculas)
        {
            IList<Aluno> alunos = new List<Aluno>();

            foreach (var matricula in matriculas)
            {
                var aluno = await _alunoRepository.GetAsync(matricula.AlunoCpf);
                if (aluno != null)
                {
                    alunos.Add(aluno);
                }
            }

            return alunos;
        }

        public async Task<Aluno> RemoveAlunoAsync(string cpf)
        {
            return await _alunoRepository.RemoveAsync(cpf);
        }
        public Aluno GetAlunoByRa(int ra)
        {
            return _alunoRepository.GetAlunoByRa(ra);
        }
    }
}
