using School.Models.Database;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School.Services.Repository
{
    public class GradeRepository : DataRepositoryBase<Grade>
    {
        public GradeRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }

        public async Task<Grade> GetGradeWithProfessorAndMatriculasAsync(int codigoGrade)
        {
            return await schoolContext.Grade
                                        .Include(g => g.Professor)
                                        .Include(g => g.Subgrades)
                                        .FirstOrDefaultAsync(g => g.CodigoGrade == codigoGrade);
        }
        public override bool EntityExists(Grade entity) => schoolContext.Grade.Any(e => e.CodigoGrade == entity.CodigoGrade);
    }
}
