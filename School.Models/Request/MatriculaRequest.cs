using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School.Models.Request
{
    public class MatriculaRequest
    {
        [JsonPropertyName("codGrade")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int CodigoGrade { get; set; }

        [JsonPropertyName("ra")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int Ra { get; set; }
    }
}
