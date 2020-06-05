using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace DomainTest.Curso
{
    public class CursoTest
    {
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
            var cursoEsperado = new
            {
                nome = "Informatica basica",
                cargaHoraria = (double)80,
                publicoAlvo = PublicoAlvo.Estudante,
                valor = (double)950
            };

            Assert.Throws<ArgumentException>(() => 
                new Curso(nomeInvalido, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, cursoEsperado.valor));
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
