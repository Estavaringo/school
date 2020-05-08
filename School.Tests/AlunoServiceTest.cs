using Moq;
using NUnit.Framework;
using School.Models.Database;
using School.Models.Request;
using School.Services;
using School.Services.Repository;
using System.Collections.Generic;
using System.Linq;

namespace School.Tests
{
    public class AlunoServiceTest
    {
        private AlunoService _alunoService;
        IList<Aluno> alunos;

        [SetUp]
        public void Setup()
        {

            var aluno1 = new Aluno("40497326884", "gabriel.estavaringo@gmail.com", "gabriel.estavaringo", "Gabriel Estavaringo", 10391246, "123456");
            var aluno2 = new Aluno("05828690566", "marcospauloolivergomes@juliosimoes.com.br", "marcos.paulo", "Marcos Paulo Oliver Gomes", 98800890, "654321");
            var aluno3 = new Aluno("15358646051", "joao.silva@anima.com.br", "joao.silva", "João da Silva", 1360523, "123");

            alunos = new List<Aluno>
            {
                aluno1, aluno2, aluno3
            };

            var repository = new Mock<AlunoRepository>(null);


            repository.Setup(x =>
                                x.GetAsync(It.IsAny<string>()))
                                .ReturnsAsync((object[] ids) => alunos.Where(a => a.Cpf == ids[0].ToString()).SingleOrDefault());

            repository.Setup(x =>
                                x.GetAsync())
                                .ReturnsAsync(alunos);

            repository.Setup(x =>
                                x.GetAlunoByRa(It.IsAny<int>()))
                                .Returns((int ra) => alunos.Where(a => a.Ra == ra).SingleOrDefault());

            repository.Setup(x =>
                                x.RemoveAsync(It.IsAny<string>()))
                                .ReturnsAsync(
                                    (object[] ids) =>
                                    {
                                        var aluno = alunos.Where(a => a.Cpf == ids[0].ToString()).SingleOrDefault();
                                        if (aluno != null)
                                        {
                                            alunos.Remove(aluno);
                                        }
                                        return aluno;
                                    });

            repository.Setup(x =>
                                x.CreateAsync(It.IsAny<Aluno>()))
                                .ReturnsAsync(
                                    (Aluno aluno) =>
                                    {
                                        if (alunos.Any(a => a.Cpf == aluno.Cpf || a.Ra == aluno.Ra))
                                        {
                                            return false;
                                        }
                                        alunos.Add(aluno);
                                        return true;
                                    });

            _alunoService = new AlunoService(repository.Object);

        }

        [Test]
        public async System.Threading.Tasks.Task CanGetAllAlunosAsync()
        {
            var actualAlunos = await _alunoService.GetAlunosAsync();

            Assert.IsNotNull(actualAlunos);
            Assert.AreEqual(alunos, actualAlunos);
        }

        [Test]
        [TestCase("40497326884")]
        [TestCase("15358646051")]
        [TestCase("abcd")]
        public async System.Threading.Tasks.Task CanGetAlunoByCpf(string cpf)
        {
            var aluno = await _alunoService.GetAlunoAsync(cpf);
            var expectedAluno = alunos.Where(a => a.Cpf == cpf).SingleOrDefault();

            Assert.AreEqual(expectedAluno, aluno);
        }

        [Test]
        [TestCase(10391246)]
        [TestCase(1360523)]
        [TestCase(0)]
        public void CanGetAlunoByRa(int ra)
        {

            var aluno = _alunoService.GetAlunoByRa(ra);

            var expectedAluno = alunos.Where(a => a.Ra == ra).SingleOrDefault();

            Assert.AreEqual(expectedAluno, aluno);
        }

        [Test]
        public async System.Threading.Tasks.Task CanCreateAlunoAsync()
        {

            var alunoRequest = new AlunoRequest("Renan Jorge Nascimento", "43172165400", "renan.nascimento", "2K2C2dgTn7", "rrenanjorgenascimento@anima.com.br", 7654321);

            var numberOfAlunos = alunos.Count();

            Assert.IsTrue(await _alunoService.CreateAlunoAsync(alunoRequest));

            Assert.AreEqual(numberOfAlunos + 1, alunos.Count());

            alunoRequest = new AlunoRequest("Renan Jorge Nascimento", "40497326884", "renan.nascimento", "2K2C2dgTn7", "rrenanjorgenascimento@anima.com.br", 7654321);

            Assert.IsFalse(await _alunoService.CreateAlunoAsync(alunoRequest));

            Assert.AreEqual(numberOfAlunos + 1, alunos.Count());
        }

        [Test]
        [TestCase("40497326884")]
        [TestCase("abcd")]
        public async System.Threading.Tasks.Task CanRemoveAlunoAsync(string cpf)
        {

            var numberOfAlunos = alunos.Count();
            var expectedAluno = alunos.Where(a => a.Cpf == cpf).SingleOrDefault();

            var aluno = await _alunoService.RemoveAlunoAsync(cpf);

            if (aluno != null)
            {
                Assert.AreEqual(numberOfAlunos - 1, alunos.Count());
            }
            else
            {
                Assert.AreEqual(numberOfAlunos, alunos.Count());
            }

            Assert.AreEqual(expectedAluno, aluno);
        }

        [Test]
        public async System.Threading.Tasks.Task CanGetAlunosByMatriculas()
        {
            var matriculas = new List<Matricula>()
            {
                new Matricula("40497326884", 123),
                new Matricula("05828690566", 456),
                new Matricula("15358646051", 789)
            };

            var actualAlunos = await _alunoService.GetAlunosByMatriculasAsync(matriculas);

            Assert.AreEqual(alunos.Count(), actualAlunos.Count());

            matriculas.Clear();

            actualAlunos = await _alunoService.GetAlunosByMatriculasAsync(matriculas);

            Assert.Zero(actualAlunos.Count());
        }



    }
}