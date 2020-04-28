using School.Models.Database;
using System.Linq;

namespace School.Services
{
    public class MatriculaRepository : DataRepositoryBase<Matricula>
    {
        public MatriculaRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }
        public override bool EntityExists(Matricula entity) => _schoolContext.Matricula.Any(e => e.FkAlunoCpf == entity.FkAlunoCpf 
                                                                                                && e.FkGradeCodigoGrade == entity.FkGradeCodigoGrade);
    }
}
