namespace School.Models
{
    public partial class Matricula
    {
        public string FkAlunoCpf { get; set; }
        public int FkGradeCodigoGrade { get; set; }

        internal virtual Aluno FkAlunoCpfNavigation { get; set; }
        internal virtual Grade FkGradeCodigoGradeNavigation { get; set; }
    }
}
