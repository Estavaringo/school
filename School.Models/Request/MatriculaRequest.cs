using System.Text.Json.Serialization;

namespace School.Models.Request
{
    public class MatriculaRequest
    {
        [JsonPropertyName("codGrade")]
        public int CodigoGrade { get; set; }

        [JsonPropertyName("ra")]
        public int Ra { get; set; }
    }
}
