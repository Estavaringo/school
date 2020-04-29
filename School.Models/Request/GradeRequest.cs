using System.Text.Json.Serialization;

namespace School.Models.Request
{
    public class GradeRequest
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

    }
}
