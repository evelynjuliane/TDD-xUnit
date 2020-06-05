using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
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
                nome = "",
                cargaHoraria = (double)80,
                publicoAlvo = "",
                valor = (double)950,
            };

            //Action
            var curso = new Curso(cursoEsperado.nome, cursoEsperado.cargaHoraria, cursoEsperado.publicoAlvo, cursoEsperado.valor);
            //Assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }
    }
    public class Curso
    {
        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valor)
        {
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}
