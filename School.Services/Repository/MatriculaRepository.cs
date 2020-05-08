using School.Models.Database;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace School.Services.Repository
{
    public class MatriculaRepository : DataRepositoryBase<Matricula>
    {
        public MatriculaRepository(SchoolContext schoolContext)
            : base(schoolContext)
        {
        }
        public override bool EntityExists(Matricula entity) => schoolContext.Matricula.Any(e => e.AlunoCpf == entity.AlunoCpf
                                                                                                && e.CodigoSubgrade == entity.CodigoSubgrade);

        public IList<Matricula> GetMatriculasBySubgrade(Subgrade subgrade)
        {
            return schoolContext.Matricula
                                        .Where(m => m.CodigoSubgrade == subgrade.CodigoSubgrade)
                                        .ToList();
        }

    }
}
