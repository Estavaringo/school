using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Matricula = new HashSet<Matricula>();
        }

        public int CodigoGrade { get; set; }
        public string NomeCurso { get; set; }
        public string NomeDisciplina { get; set; }
        public string NomeTurma { get; set; }
        public string FkProfessorCpf { get; set; }

        public virtual Professor FkProfessorCpfNavigation { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
