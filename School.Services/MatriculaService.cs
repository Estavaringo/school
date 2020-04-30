using School.Models.Database;
using School.Models.Request;
using School.Services.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services
{
    public class MatriculaService
    {
        private readonly MatriculaRepository _matriculaRepository;
        private readonly AlunoService _alunoService;

        public MatriculaService(MatriculaRepository matriculaRepository, AlunoService alunoService)
        {
            _matriculaRepository = matriculaRepository;
            _alunoService = alunoService;
        }

        public async Task<Matricula> GetMatriculaAsync(MatriculaRequest matriculaRequest)
        {
            var aluno = _alunoService.GetAlunoByRa(matriculaRequest.Ra);

            return await _matriculaRepository.GetAsync(aluno.Cpf, matriculaRequest.CodigoGrade);
        }

        public async Task<IEnumerable<Matricula>> GetMatriculasAsync()
        {
            return await _matriculaRepository.GetAsync();
        }

        public async Task<bool> CreateMatriculaAsync(MatriculaRequest matriculaRequest)
        {
            var aluno = _alunoService.GetAlunoByRa(matriculaRequest.Ra);

            var matricula = new Matricula(aluno.Cpf, matriculaRequest.CodigoGrade);

            return await _matriculaRepository.CreateAsync(matricula);
        }

        public async Task<Matricula> RemoveMatriculaAsync(MatriculaRequest matriculaRequest)
        {
            var aluno = _alunoService.GetAlunoByRa(matriculaRequest.Ra);

            return await _matriculaRepository.RemoveAsync(aluno.Cpf, matriculaRequest.CodigoGrade);
        }
    }
}
