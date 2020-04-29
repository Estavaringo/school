using System.Text.Json.Serialization;

namespace School.Models.Request
{
    public class AlunoRequest
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

        [JsonPropertyName("ra")]
        public int Ra { get; set; }
    }
}
