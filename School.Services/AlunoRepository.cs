using School.Models.Database;
using System.Linq;

namespace School.Services
{
    public class AlunoRepository : DataRepositoryBase<Aluno>
    {
        public AlunoRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }

        public override bool EntityExists(Aluno entity) => _schoolContext.Aluno.Any(e => e.Ra == entity.Ra 
                                                                                        || e.Cpf == entity.Cpf);
    }
}
