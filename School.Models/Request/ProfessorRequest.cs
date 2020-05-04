using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace School.Models.Request
{
    public class ProfessorRequest
    {

        [JsonProperty("nome")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(60, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Nome { get; set; }

        [JsonProperty("cpf")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(11, ErrorMessage = "{0} length must be {1}", MinimumLength = 11)]
        public string Cpf { get; set; }

        [JsonProperty("login")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(60, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Login { get; set; }

        [JsonProperty("senha")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(60, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Senha { get; set; }

        [JsonProperty("email")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        [StringLength(60, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Email { get; set; }

        [JsonProperty("codigo")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int Codigo { get; set; }
    }
}
