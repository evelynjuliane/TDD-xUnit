using Application.DTO;
using Domain.Cursos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }
        public void Armazenar(CursoDTO cursoDTO)
        {

            var cursoSalvo = _cursoRepositorio.ObterPeloNome(cursoDTO.Nome);

            if (cursoSalvo != null)
                throw new ArgumentException("Nome do curso já consta no banco de dados");

            if(!Enum.TryParse<PublicoAlvo>(cursoDTO.PublicoAlvo, out var publicoAlvo))
                throw new ArgumentException("Nome Do curso já consta no banco de dados");

            var curso = 
                new Curso(cursoDTO.Nome, cursoDTO.CargaHoraria, publicoAlvo, cursoDTO.Valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }
}
