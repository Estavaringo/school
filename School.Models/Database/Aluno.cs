﻿using System.Collections.Generic;

namespace School.Models.Database
{
    public partial class Aluno
    {
        public Aluno()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public Aluno(string cpf, string email, string login, string nome, int ra, string senha)
        {
            Cpf = cpf;
            Email = email;
            Login = login;
            Nome = nome;
            Ra = ra;
            Senha = senha;
        }

        public string Cpf { get; set; }
        public int Ra { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
