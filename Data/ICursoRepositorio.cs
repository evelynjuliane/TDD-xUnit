using Domain.Cursos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
        Curso ObterPeloNome(string nome);
    }
}
