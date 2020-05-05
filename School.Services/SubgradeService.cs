using School.Helpers;
using School.Models.Database;
using School.Services.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services
{
    public class SubgradeService
    {
        private readonly SubgradeRepository _subgradeRepository;

        public SubgradeService(SubgradeRepository subgradeRepository)
        {
            _subgradeRepository = subgradeRepository;
        }

        public async Task<Subgrade> GetSubgradeAsync(int codigoSubgrade)
        {
            return await _subgradeRepository.GetAsync(codigoSubgrade);
        }

        public async Task<IList<Subgrade>> GetSubgradesAsync(int codigoGrade)
        {
            return await _subgradeRepository.GetSubgradesByCodigoGradeAsync(codigoGrade);
        }

        private async Task<bool> CreateSubgradeAsync(Subgrade subgrade)
        {
            return await _subgradeRepository.CreateAsync(subgrade);
        }

        public async Task<Subgrade> RemoveSubgradeAsync(int codigoSubgrade)
        {
            return await _subgradeRepository.RemoveAsync(codigoSubgrade);
        }

        /// <summary>
        /// Get the subgrade code to create a matricula.
        /// </summary>
        /// <param name="codigoGrade"></param>
        /// <returns></returns>
        public async Task<int> GetCodigoSubgradeToCreateMatriculaAsync(int codigoGrade)
        {
            var subgrade = await GetOrCreateAsync(codigoGrade);
            if (subgrade.Matriculas.Count == Constants.MAX_STUDENTS)
            {
                await SetSubgradeFullAsync(subgrade);
                subgrade = await GetOrCreateAsync(codigoGrade);
            }
            return subgrade.CodigoSubgrade;
        }

        /// <summary>
        /// Gets a Subgrade by the param codigoGrade. If the Subgrade doesn't exists or it's full, it creates a new one.
        /// </summary>
        /// <param name="codigoGrade"></param>
        /// <returns></returns>
        public async Task<Subgrade> GetOrCreateAsync(int codigoGrade)
        {
            var subgrade = await _subgradeRepository.GetSubgradeNotFullByCodigoGradeAsync(codigoGrade);
            if (subgrade == null)
            {
                subgrade = new Subgrade(codigoGrade);
                await CreateSubgradeAsync(subgrade);
            }
            return subgrade;
        }

        public async Task SetSubgradeFullAsync(Subgrade subgrade)
        {
            subgrade.Cheia = true;
            await _subgradeRepository.EditAsync(subgrade);
        }

        public async Task SetSubgradeNotFullAsync(int codigoSubgrade)
        {
            var subgrade = await GetSubgradeAsync(codigoSubgrade);
            if (subgrade.Cheia == true)
            {
                subgrade.Cheia = false;
                await _subgradeRepository.EditAsync(subgrade);
            }
        }
    }
}
