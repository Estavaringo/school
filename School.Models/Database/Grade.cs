using System.Collections.Generic;

namespace School.Models.Database
{
    public partial class Grade
    {
        public Grade()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public Grade(int codigoGrade, string turma, string disciplina, string curso, string cpf)
        {
            CodigoGrade = codigoGrade;
            NomeTurma = turma;
            NomeDisciplina = disciplina;
            NomeCurso = curso;
            ProfessorCpf = cpf;
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
