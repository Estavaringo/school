using School.Models.Database;
using School.Models.Request;
using School.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services
{
    public class MatriculaService
    {
        private readonly MatriculaRepository _matriculaRepository;
        private readonly AlunoService _alunoService;
        private readonly SubgradeService _subgradeService;

        public MatriculaService(MatriculaRepository matriculaRepository, AlunoService alunoService, SubgradeService subgradeService)
        {
            _matriculaRepository = matriculaRepository;
            _alunoService = alunoService;
            _subgradeService = subgradeService;
        }

        public async Task<bool> CreateMatriculaAsync(MatriculaRequest matriculaRequest)
        {

            var aluno = _alunoService.GetAlunoByRa(matriculaRequest.Ra);

            if(MatriculaExist(aluno, matriculaRequest.CodGrade))
            {
                return false;
            }

            var codigoSubgrade = await _subgradeService.GetCodigoSubgradeToCreateMatriculaAsync(matriculaRequest.CodGrade);

            var matricula = new Matricula(aluno.Cpf, codigoSubgrade);

            return await _matriculaRepository.CreateAsync(matricula);
        }

        public IList<Matricula> GetMatriculasBySubgrades(ICollection<Subgrade> subgrades)
        {
            List<Matricula> matriculas = new List<Matricula>();
            foreach (var subgrade in subgrades)
            {
                var matricula = _matriculaRepository.GetMatriculasBySubgrade(subgrade);
                if (matricula != null)
                {
                    matriculas.AddRange(matricula);
                }
            }
            return matriculas;
        }

        public async Task<Matricula> RemoveMatriculaAsync(MatriculaRequest matriculaRequest)
        {
            var aluno = _alunoService.GetAlunoByRa(matriculaRequest.Ra);
            if (aluno != null)
            {
                foreach (var matricula in aluno.Matriculas)
                {
                    if (matricula.Subgrade.CodigoGrade == matriculaRequest.CodGrade)
                    {
                        var matriculaDeleted = await _matriculaRepository.RemoveAsync(aluno.Cpf, matricula.CodigoSubgrade);
                        await _subgradeService.SetSubgradeNotFullAsync(matricula.CodigoSubgrade);
                        return matriculaDeleted;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Check if aluno has a matricula in any of the subgrades
        /// </summary>
        /// <param name="aluno"></param>
        /// <param name="codigoGrade"></param>
        /// <returns></returns>
        private bool MatriculaExist(Aluno aluno, int codigoGrade) => aluno.Matriculas.Any(m => m.Subgrade.CodigoGrade == codigoGrade);

    }
}