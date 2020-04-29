using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace School.Models.Response
{

    public class GradeResponse
    {

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
