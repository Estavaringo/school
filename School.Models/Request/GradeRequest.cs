using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace School.Models.Request
{
    public class GradeRequest
    {

        [JsonProperty("codGrade")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int CodigoGrade { get; set; }

        [JsonProperty("turma")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(100, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Turma { get; set; }

        [JsonProperty("disciplina")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(100, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Disciplina { get; set; }

        [JsonProperty("curso")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(100, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Curso { get; set; }

        [JsonProperty("codFuncionario")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int CodigoFuncionario { get; set; }

    }
}
