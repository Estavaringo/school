using School.Models.Database;
using System.Linq;

namespace School.Services.Repository
{
    public class GradeRepository : DataRepositoryBase<Grade>
    {
        public GradeRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }
        public override bool EntityExists(Grade entity) => _schoolContext.Grade.Any(e => e.CodigoGrade == entity.CodigoGrade);
    }
}
