using Microsoft.EntityFrameworkCore;

namespace School.Models
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Aluno__C1F897309182AD86");

                entity.ToTable("Aluno", "dbo");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Ra)
                    .HasColumnName("RA")
                    .IsRequired();

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.CodigoGrade)
                    .HasName("PK__Grade__A689F981E3781367");

                entity.ToTable("Grade", "dbo");

                entity.Property(e => e.CodigoGrade)
                    .HasColumnName("Codigo_Grade")
                    .ValueGeneratedNever()
                    .IsRequired();

                entity.Property(e => e.FkProfessorCpf)
                    .IsRequired()
                    .HasColumnName("fk_Professor_CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NomeCurso)
                    .IsRequired()
                    .HasColumnName("Nome_Curso")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeDisciplina)
                    .IsRequired()
                    .HasColumnName("Nome_Disciplina")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeTurma)
                    .IsRequired()
                    .HasColumnName("Nome_Turma")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkProfessorCpfNavigation)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.FkProfessorCpf)
                    .HasConstraintName("FK_Grade_2");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => new { e.FkAlunoCpf, e.FkGradeCodigoGrade })
                    .HasName("PK__Matricul__39600E4D3BE77FC5");

                entity.ToTable("Matricula", "dbo");

                entity.Property(e => e.FkAlunoCpf)
                    .HasColumnName("FK_Aluno_CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .IsRequired();

                entity.Property(e => e.FkGradeCodigoGrade)
                    .HasColumnName("FK_Grade_Codigo_Grade")
                    .IsRequired();

                entity.HasOne(d => d.FkAlunoCpfNavigation)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.FkAlunoCpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_2");

                entity.HasOne(d => d.FkGradeCodigoGradeNavigation)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.FkGradeCodigoGrade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_1");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Professo__C1F89730E4FAB398");

                entity.ToTable("Professor", "dbo");

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .IsRequired();

                entity.Property(e => e.CodigoFuncionario)
                    .HasColumnName("Codigo_Funcionario")
                    .IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
