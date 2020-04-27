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

        internal virtual Professor FkProfessorCpfNavigation { get; set; }
        internal virtual ICollection<Matricula> Matricula { get; set; }
    }
}
