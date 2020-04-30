using System.Text.Json.Serialization;

namespace School.Models.Response
{
    public class ProfessorResponse
    {

        [JsonPropertyName("codFuncionario")]
        public int CodigoFuncionario { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("totalGrades")]
        public int TotalGrades { get; set; }

        [JsonPropertyName("totalAlunos")]
        public int TotalAlunos { get; set; }

        [JsonPropertyName("salario")]
        public int Salario { get; set; }
    }
}

