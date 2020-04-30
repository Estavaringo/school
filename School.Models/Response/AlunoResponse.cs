using School.Models.Database;
using System;
using System.Text.Json.Serialization;

namespace School.Models.Response
{
    public class AlunoResponse
    {
        public AlunoResponse(Aluno aluno)
        {
            if (aluno == null)
            {
                throw new ArgumentNullException(nameof(aluno));
            }
            Nome = aluno.Nome;
            Ra = aluno.Ra;
            Email = aluno.Email;
        }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("ra")]
        public int Ra { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

}
