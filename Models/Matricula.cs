using System;
using System.Collections.Generic;

namespace School.Models
{
    public partial class Matricula
    {
        public string FkAlunoCpf { get; set; }
        public int FkGradeCodigoGrade { get; set; }

        public virtual Aluno FkAlunoCpfNavigation { get; set; }
        public virtual Grade FkGradeCodigoGradeNavigation { get; set; }
    }
}
