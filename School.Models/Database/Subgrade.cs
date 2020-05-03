using System;
using System.Collections.Generic;

namespace School.Models.Database
{
    public partial class Subgrade
    {
        public Subgrade()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int CodigoSubgrade { get; set; }
        public bool Cheia { get; set; }
        public int CodigoGrade { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
