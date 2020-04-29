using System.Text.Json.Serialization;

namespace School.Models.Response
{
    public class AlunoResponse
    {

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("ra")]
        public int Ra { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

}
