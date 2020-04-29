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

        public override bool EntityExists(Aluno entity) => _schoolContext.Aluno.Any(e => e.Ra == entity.Ra
                                                                                        || e.Cpf == entity.Cpf);
        internal Aluno GetAlunoByRa(int ra)
        {
            return _schoolContext.Aluno.Where(a => a.Ra == ra).FirstOrDefault();
        }
    }
}
