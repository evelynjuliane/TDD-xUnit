using Bogus;
using Domain.Cursos;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DomainTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly CursoDTO _cursoDTO;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;

        public ArmazenadorDeCursoTest()
        {
            var fake = new Faker();
            _cursoDTO = new CursoDTO
            {
                Nome = fake.Random.Words(),
                CargaHoraria = fake.Random.Double(50, 1000),
                PublicoAlvo = "Estudante",
                Valor = fake.Random.Double(1000, 2000)
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }
        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDTO);
            
            _cursoRepositorioMock.Verify(x => x.Adicionar(
                It.Is<Curso>(
                    c => c.Nome == _cursoDTO.Nome && 
                    c.CargaHoraria == _cursoDTO.CargaHoraria &&
                    c.Valor == _cursoDTO.Valor)
                //), Times.Atleast(2));Verifica quantas vezes o metodo foi chamado
                //), Times.Never);
                ));
        }
        [Fact]
        public void NaoDeveAdicionarComPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Médico";
            _cursoDTO.PublicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDTO));
        }
    }
    
    public interface ICursoRepositorio
    {
        public void Adicionar(Curso curso);
    }
    public class ArmazenadorDeCurso
    {
        public readonly ICursoRepositorio _cursoRepositorio;
        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }
        public void Armazenar(CursoDTO cursoDTO)
        {
            Enum.TryParse(typeof(PublicoAlvo), cursoDTO.PublicoAlvo, out var publicoAlvo);
            if (publicoAlvo == null)
                throw new ArgumentException("Publico Alvo Inválido");

            var _curso = new Curso(cursoDTO.Nome, cursoDTO.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDTO.Valor);

            _cursoRepositorio.Adicionar(_curso);
        }
    }

    public class CursoDTO
    {
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }
    }
    
}
