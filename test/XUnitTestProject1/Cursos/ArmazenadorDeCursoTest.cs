using Application.DTO;
using Bogus;
using Data;
using Domain.Cursos;
using DomainTest.Builders;
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
            //Moq valida o Objeto
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
        [Fact]
        public void NaoDeveAdicionarCursoComMesmoNome()
        {
            //STUB = simula comportamento 
            var cursoSalvo = CursoBuilder.Novo().ComNome(_cursoDTO.Nome).Build();
            _cursoRepositorioMock.Setup(r => r.ObterPeloNome(_cursoDTO.Nome)).Returns(cursoSalvo);

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDTO));
        
        }
    }
    
    
    

    
    
}
