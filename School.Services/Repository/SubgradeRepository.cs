using Microsoft.EntityFrameworkCore;
using School.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Services.Repository
{
    public class SubgradeRepository : DataRepositoryBase<Subgrade>
    {
        public SubgradeRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }

        public override bool EntityExists(Subgrade entity) => schoolContext.Subgrade.Any(e => e.CodigoSubgrade == entity.CodigoSubgrade);

        public async Task<Subgrade> GetSubgradeNotFullByCodigoGradeAsync(int codigoGrade)
        {
            return await schoolContext.Subgrade
                                        .Include(s => s.Matriculas)
                                        .FirstOrDefaultAsync(s => s.Cheia == false && s.CodigoGrade == codigoGrade);
        }

        internal async Task<IList<Subgrade>> GetSubgradesByCodigoGradeAsync(int codigoGrade)
        {
            return await schoolContext.Subgrade
                                    .Include(s => s.Matriculas)
                                    .Where(s => s.CodigoGrade == codigoGrade).ToListAsync();
        }
    }
}
