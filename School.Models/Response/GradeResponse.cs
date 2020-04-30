using School.Models.Database;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace School.Models.Response
{

    public class GradeResponse
    {
        private Grade grade;

        public GradeResponse(Grade grade, IList<Aluno> alunos)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }
            if (grade.Professor == null)
            {
                throw new ArgumentNullException(nameof(grade.Professor));
            }
            CodigoGrade = grade.CodigoGrade;
            Turma = grade.NomeTurma;
            Disciplina = grade.NomeDisciplina;
            Curso = grade.NomeCurso;
            CodigoFuncionario = grade.Professor.CodigoFuncionario;
            NomeProfessor = grade.Professor.Nome;
            CpfProfessor = grade.Professor.Cpf;
            EmailProfessor = grade.Professor.Email;
            Alunos = new List<AlunoResponse>();
            foreach(Aluno aluno in alunos)
            {
                Alunos.Add(new AlunoResponse(aluno));
            }
        }

        [JsonPropertyName("codGrade")]
        public int CodigoGrade { get; set; }

        [JsonPropertyName("turma")]
        public string Turma { get; set; }

        [JsonPropertyName("disciplina")]
        public string Disciplina { get; set; }

        [JsonPropertyName("curso")]
        public string Curso { get; set; }

        [JsonPropertyName("codFuncionario")]
        public int CodigoFuncionario { get; set; }

        [JsonPropertyName("nomeProfessor")]
        public string NomeProfessor { get; set; }

        [JsonPropertyName("cpfProfessor")]
        public string CpfProfessor { get; set; }

        [JsonPropertyName("emailProfessor")]
        public string EmailProfessor { get; set; }

        [JsonPropertyName("alunos")]
        public IList<AlunoResponse> Alunos { get; set; }
    }
}
