namespace School.Models.Database
{
    public partial class Matricula
    {
        public Matricula(string alunoCpf, int codigoSubgrade)
        {
            CodigoSubgrade = codigoSubgrade;
            AlunoCpf = alunoCpf;
        }

        public string AlunoCpf { get; set; }
        public int CodigoSubgrade { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Subgrade Subgrade { get; set; }
    }
}
