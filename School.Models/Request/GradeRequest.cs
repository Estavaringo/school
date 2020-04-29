using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School.Models.Request
{
    public class GradeRequest
    {

        [JsonPropertyName("codGrade")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int CodigoGrade { get; set; }

        [JsonPropertyName("turma")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(100, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Turma { get; set; }

        [JsonPropertyName("disciplina")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(100, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Disciplina { get; set; }

        [JsonPropertyName("curso")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(100, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Curso { get; set; }

        [JsonPropertyName("codFuncionario")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int CodigoFuncionario { get; set; }

    }
}
