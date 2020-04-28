using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace School.Models.Database
{
    public partial class Grade
    {
        public Grade()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int CodigoGrade { get; set; }

        public string NomeCurso { get; set; }

        public string NomeDisciplina { get; set; }

        public string NomeTurma { get; set; }

        public string ProfessorCpf { get; set; }

        internal virtual Professor Professor { get; set; }
        internal virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
