using System.Text.Json.Serialization;

namespace School.Models.Request
{
    public class ProfessorRequest
    {

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("senha")]
        public string Senha { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("codigo")]
        public int Codigo { get; set; }
    }
}
