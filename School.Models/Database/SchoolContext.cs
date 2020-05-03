using Microsoft.EntityFrameworkCore;

namespace School.Models.Database
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
        public virtual DbSet<Subgrade> Subgrade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Aluno__C1F89730D5327914");

                entity.ToTable("Aluno", "dbo");

                entity.HasIndex(e => e.Ra)
                    .HasName("UQ__Aluno__321537CE96AD1E80")
                    .IsUnique();

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
                    .HasName("PK__Grade__A689F98105D7CAA7");

                entity.ToTable("Grade", "dbo");

                entity.Property(e => e.CodigoGrade)
                    .HasColumnName("Codigo_Grade")
                    .ValueGeneratedNever()
                    .IsRequired();

                entity.Property(e => e.ProfessorCpf)
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

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.ProfessorCpf)
                    .HasConstraintName("FK_Grade_2");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasKey(e => new { e.AlunoCpf, e.CodigoSubgrade })
                    .HasName("PK__Matricul__F04EF5F351D7FC5F");

                entity.ToTable("Matricula", "dbo");

                entity.Property(e => e.AlunoCpf)
                    .HasColumnName("FK_Aluno_CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .IsRequired();

                entity.Property(e => e.CodigoSubgrade)
                    .HasColumnName("FK_Subgrade_Codigo_Subgrade")
                    .IsRequired();

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.AlunoCpf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_2");

                entity.HasOne(d => d.Subgrade)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.CodigoSubgrade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matricula_1");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Professo__C1F89730B2B6568A");

                entity.ToTable("Professor", "dbo");

                entity.HasIndex(e => e.CodigoFuncionario)
                    .HasName("UQ__Professo__0CB8542CEFCE1FD1")
                    .IsUnique();

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

            modelBuilder.Entity<Subgrade>(entity =>
            {
                entity.HasKey(e => e.CodigoSubgrade)
                    .HasName("PK__Subgrade__18806DDAD2E2AC7C");

                entity.ToTable("Subgrade", "dbo");

                entity.Property(e => e.CodigoSubgrade)
                    .HasColumnName("Codigo_Subgrade")
                    .IsRequired();

                entity.Property(e => e.CodigoGrade)
                    .HasColumnName("FK_Grade_Codigo_Grade")
                    .IsRequired();

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Subgrades)
                    .HasForeignKey(d => d.CodigoGrade)
                    .HasConstraintName("FK_Subgrade_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
