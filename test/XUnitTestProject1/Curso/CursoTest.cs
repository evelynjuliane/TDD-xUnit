using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DomainTest.Curso
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

            _nome = "Microsoft Office";
            _cargaHoraria = 80;
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = 950;
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
            var curso = new Curso(cursoEsperado.nome, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, cursoEsperado.valor);
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
                new Curso(nomeInvalido, _cargaHoraria, _publicoAlvo, _valor));
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {

            Assert.Throws<ArgumentException>(() =>
                new Curso(_nome, cargaHorariaInvalida, _publicoAlvo, _valor));

        }
        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenor1(double valorInvalido)
        {
;
            Assert.Throws<ArgumentException>(() =>
                new Curso(_nome, _cargaHoraria, _publicoAlvo, valorInvalido));
        }

    }
    public enum PublicoAlvo
    {
        Estudante, 
        Universitário,
        Empregado,
        Empreendedor
    }
    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException();
            }
            if(cargaHoraria < 1)
            {
                throw new ArgumentException();
            }
            if(valor < 1)
            {
                throw new ArgumentException();
            }

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}
