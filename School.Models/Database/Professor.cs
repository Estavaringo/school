using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace School.Models.Database
{
    public partial class Professor
    {
        public Professor()
        {
            Grades = new HashSet<Grade>();
        }

        public string Cpf { get; set; }

        public int CodigoFuncionario { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
