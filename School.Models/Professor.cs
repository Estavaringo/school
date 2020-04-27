using System.Collections.Generic;

namespace School.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Grade = new HashSet<Grade>();
        }

        public string Cpf { get; set; }
        public int CodigoFuncionario { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }

        internal virtual ICollection<Grade> Grade { get; set; }
    }
}
