using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace School.Models.Request
{
    public class AlunoRequest
    {

        public AlunoRequest(string nome, string cpf, string login, string senha, string email, int ra)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Login = login;
            this.Senha = senha;
            this.Email = email;
            this.Ra = ra;
        }

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

        [JsonProperty("ra")]
        [Required(ErrorMessage = "{0} cannot be null.")]
        public int Ra { get; set; }
    }
}
