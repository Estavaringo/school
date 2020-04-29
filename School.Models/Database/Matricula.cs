namespace School.Models.Database
{
    public partial class Matricula
    {
        public string AlunoCpf { get; set; }
        public int CodigoGrade { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
