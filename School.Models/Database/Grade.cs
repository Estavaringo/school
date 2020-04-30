using System.Collections.Generic;

namespace School.Models.Database
{
    public partial class Grade
    {

        public Grade(int codigoGrade, string nomeTurma, string nomeDisciplina, string nomeCurso, string professorCpf)
        {
            CodigoGrade = codigoGrade;
            NomeTurma = nomeTurma;
            NomeDisciplina = nomeDisciplina;
            NomeCurso = nomeCurso;
            ProfessorCpf = professorCpf;
            Matriculas = new HashSet<Matricula>();
        }

        public int CodigoGrade { get; set; }

        public string NomeCurso { get; set; }

        public string NomeDisciplina { get; set; }

        public string NomeTurma { get; set; }

        public string ProfessorCpf { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
