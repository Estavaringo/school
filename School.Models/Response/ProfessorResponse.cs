using System.Text.Json.Serialization;

namespace School.Models.Response
{
    public class ProfessorResponse
    {
        public ProfessorResponse(int codigoFuncionario, string nome, string cpf, string email, int totalGrades, int totalAlunos, double salary)
        {
            CodFuncionario = codigoFuncionario;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            TotalGrades = totalGrades;
            TotalAlunos = totalAlunos;
            Salario = salary;
        }

        [JsonPropertyName("codFuncionario")]
        public int CodFuncionario { get; set; }

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
        public double Salario { get; set; }
    }
}

