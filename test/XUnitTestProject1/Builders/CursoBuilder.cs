using Domain.Cursos;
using DomainTest.Cursos;

namespace DomainTest.Builders
{
    public class CursoBuilder
    {
        private string _nome = "Microsoft Office";
        private double _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 950;


        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }
        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }
        public CursoBuilder ComCaragaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }
        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }
        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }
        public Curso Build()
        {
            return new Curso(_nome, _cargaHoraria, _publicoAlvo, _valor);
        }

    }
}
