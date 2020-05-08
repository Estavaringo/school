using School.Models.Database;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School.Services.Repository
{
    public class ProfessorRepository : DataRepositoryBase<Professor>
    {
        public ProfessorRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }

        public override bool EntityExists(Professor entity) => schoolContext.Professor.Any(e => e.CodigoFuncionario == entity.CodigoFuncionario
                                                                                                || e.Cpf == entity.Cpf);

        public Professor GetProfessorByCodigoFuncionario(int codigoFuncionario)
        {
            return schoolContext.Professor.Where(p => p.CodigoFuncionario == codigoFuncionario).FirstOrDefault();
        }

        public Task<Professor> GetProfessorWithGradeAsync(string cpf)
        {
            return schoolContext.Professor
                                    .Include(p => p.Grades)
                                        .ThenInclude(g => g.Subgrades)
                                            .ThenInclude(s => s.Matriculas)
                                    .SingleAsync(p => p.Cpf == cpf);
        }
    }
}
