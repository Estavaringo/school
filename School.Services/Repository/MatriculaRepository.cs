using School.Models.Database;
using System.Linq;

namespace School.Services.Repository
{
    public class MatriculaRepository : DataRepositoryBase<Matricula>
    {
        public MatriculaRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }
        public override bool EntityExists(Matricula entity) => _schoolContext.Matricula.Any(e => e.AlunoCpf == entity.AlunoCpf 
                                                                                                && e.CodigoGrade == entity.CodigoGrade);
    }
}
