using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School.Models.Request
{
    public class ProfessorRequest
    {

        [JsonPropertyName("nome")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(60, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Nome { get; set; }

        [JsonPropertyName("cpf")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(11, ErrorMessage = "{0} length must be {1}", MinimumLength = 11)]
        public string Cpf { get; set; }

        [JsonPropertyName("login")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(60, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Login { get; set; }

        [JsonPropertyName("senha")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(60, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Senha { get; set; }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(60, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Email { get; set; }

        [JsonPropertyName("codigo")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int Codigo { get; set; }
    }
}
