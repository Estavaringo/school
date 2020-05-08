using Microsoft.EntityFrameworkCore;
using School.Models.Database;
using System.Linq;

namespace School.Services.Repository
{
    public class AlunoRepository : DataRepositoryBase<Aluno>
    {
        public AlunoRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }

        public override bool EntityExists(Aluno entity) => schoolContext.Aluno.Any(e => e.Ra == entity.Ra
                                                                                        || e.Cpf == entity.Cpf);
        public virtual Aluno GetAlunoByRa(int ra)
        {
            return schoolContext.Aluno
                                    .Include(a => a.Matriculas)
                                        .ThenInclude(m => m.Subgrade)
                                    .Where(a => a.Ra == ra).FirstOrDefault();
        }
    }
}
