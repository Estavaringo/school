using Microsoft.EntityFrameworkCore;
using School.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services
{
    public class AlunoService
    {
        private readonly SchoolContext _schoolContext;

        public AlunoService(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task<IEnumerable<Aluno>> GetAsync()
        {
            return await _schoolContext.Aluno.ToListAsync();
        }

        public async Task<Aluno> GetAsync(string id)
        {
            return await _schoolContext.Aluno.FindAsync(id);
        }

        public async Task<bool> EditAsync(string id, Aluno aluno)
        {
            _schoolContext.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _schoolContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> CreateAsync(Aluno aluno)
        {
            _schoolContext.Aluno.Add(aluno);
            try
            {
                await _schoolContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlunoExists(aluno.Cpf) || AlunoExists(aluno.Ra))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<Aluno> RemoveAsync(string id)
        {
            var aluno = await _schoolContext.Aluno.FindAsync(id);

            if (aluno != null)
            {
                _schoolContext.Aluno.Remove(aluno);
                await _schoolContext.SaveChangesAsync();
            }
            return aluno;
        }

        private bool AlunoExists(string id) => _schoolContext.Aluno.Any(e => e.Cpf == id);
        private bool AlunoExists(int ra) => _schoolContext.Aluno.Any(e => e.Ra == ra);

    }
}
