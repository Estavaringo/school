using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            Matricula = new HashSet<Matricula>();
        }

        public string Cpf { get; set; }
        public int Ra { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }

        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
