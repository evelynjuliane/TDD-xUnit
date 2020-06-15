using Bogus;
using Domain.Cursos;
using DomainTest.Builders;
using System;
using Xunit;
using Xunit.Abstractions;

namespace DomainTest.Cursos
{
    public class CursoTest
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor Executado");
            var faker = new Faker();

            _nome = faker.Random.Word();
            _cargaHoraria = faker.Random.Double(50, 1000);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(100, 1000);

            
            _output.WriteLine($"Double: {faker.Random.Double(1, 100)}");
            _output.WriteLine($"Comapany: {faker.Company.CompanyName()}");
            _output.WriteLine($"Email: {faker.Person.Email}");

        }
        [Fact]
        public void DeveCriarCurso()
        {
            //Arrange  
            var cursoEsperado = new
            {
                nome = "Microsoft Office",
                cargaHoraria = (double)80,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = (double)950
            };

            //Action
            var curso = new Curso(cursoEsperado.nome,
                                  cursoEsperado.cargaHoraria,
                                  cursoEsperado.publicoAlvo,
                                  cursoEsperado.valor);
            //Assert
            Assert.Equal(cursoEsperado.nome, curso.Nome);
            Assert.Equal(cursoEsperado.cargaHoraria, curso.CargaHoraria);
            Assert.Equal(cursoEsperado.publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(cursoEsperado.valor, curso.Valor);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComNome(nomeInvalido).Build());
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComCaragaHoraria(cargaHorariaInvalida).Build());

        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenor1(double valorInvalido)
        {
;
            Assert.Throws<ArgumentException>(() =>
               CursoBuilder.Novo().ComValor(valorInvalido).Build());
        }

    }
   
    
}
