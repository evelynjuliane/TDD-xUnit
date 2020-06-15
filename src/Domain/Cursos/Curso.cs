using System;


namespace Domain.Cursos
{
    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            isValid(nome,cargaHoraria, publicoAlvo, valor);
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get;  private set; }

        public void isValid(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException();
            }
            if (cargaHoraria < 1)
            {
                throw new ArgumentException();
            }
            if (valor < 1)
            {
                throw new ArgumentException();
            }
        }
    }
}
