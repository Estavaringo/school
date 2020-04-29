using System.Collections.Generic;

namespace School.Models.Database
{
    public partial class Professor
    {

        public Professor()
        {
            Grades = new HashSet<Grade>();
        }

        public Professor(string cpf, string email, string login, string nome, int codigo, string senha)
        {
            Cpf = cpf;
            Email = email;
            Login = login;
            Nome = nome;
            CodigoFuncionario = codigo;
            Senha = senha;
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
