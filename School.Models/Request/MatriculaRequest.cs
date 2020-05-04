using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace School.Models.Request
{
    public class MatriculaRequest
    {
        [JsonProperty("codGrade")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int CodigoGrade { get; set; }

        [JsonProperty("ra")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int Ra { get; set; }
    }
}
