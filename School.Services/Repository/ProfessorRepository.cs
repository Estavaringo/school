using School.Models.Database;
using System.Linq;

namespace School.Services.Repository
{
    public class ProfessorRepository : DataRepositoryBase<Professor>
    {
        public ProfessorRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }

        public override bool EntityExists(Professor entity) => _schoolContext.Professor.Any(e => e.CodigoFuncionario == entity.CodigoFuncionario
                                                                                                || e.Cpf == entity.Cpf);

        public Professor GetProfessorByCodigoFuncionario(int codigoFuncionario)
        {
            return _schoolContext.Professor.Where(p => p.CodigoFuncionario == codigoFuncionario).FirstOrDefault();
        }
    }
}
