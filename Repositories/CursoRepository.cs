using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Interfaces;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Repositories
{
    public class CursoRepository : ICursoRepository
    {
       private readonly CursoDistanciaContext _context;
        public CursoRepository(CursoDistanciaContext context)
        {
            _context = context;
        }


         public Curso Insert(int Id, Curso curso)
        {
            _context.Add(curso);
            _context.SaveChanges();
            return curso;
        }

         public ICollection<Curso> GetALL()
        {
            var curso  = _context.Cursos.ToList();
            if(curso == null || curso.Count == 0)
            {
                return new List<Curso>{new Curso {titulo = " Nenhum usúario cadastrado. "}};
            }
            return curso;
        }

        public Curso Update(int Id, Curso curso)
        {
           var cursoBanco = _context.Cursos.Find(Id);
               if(cursoBanco == null)
                    throw new Exception("Item não encontrado com o ID fornecido.");
                    
                    cursoBanco.titulo = curso.titulo;
                    cursoBanco.Descricao = curso.Descricao;
                    cursoBanco.dataInicio = curso.dataInicio;
                    cursoBanco.dataFim = curso.dataFim;
                    cursoBanco.Instrutor = curso.Instrutor;

                _context.Cursos.Update(cursoBanco);
                _context.SaveChanges();

                return cursoBanco;
        }

        public bool Delete(int Id)
        {
            var aulaBanco = _context.Aulas.Find(Id);

                if ( aulaBanco == null )
                    throw new Exception("Item não encontrado com o ID fornecido.");

                _context.Aulas.Remove(aulaBanco);
                _context.SaveChanges();

                return true;
        }

        public Curso GetBuId(int id)
        {
            return _context.Cursos.Find(id);
        }
    }
}