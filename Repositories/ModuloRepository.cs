using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Interfaces;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly CursoDistanciaContext _context;
        public ModuloRepository(CursoDistanciaContext context)
        {
            _context = context;
        }
        public Modulo Insert(int id, Modulo modulo)
        {
            _context.Add(modulo);
            _context.SaveChanges();
            return modulo;
        }
         public ICollection<Modulo> GetALL()
        {
            var modulo  = _context.Modulos.ToList();
            if(modulo == null || modulo.Count == 0)
            {
                return new List<Modulo>{new Modulo {titulo = " Nenhum usúario cadastrado. "}};
            }
            return modulo;
        }
        public Modulo Update(int id, Modulo modulo)
        {
           var moduloBanco = _context.Modulos.Find(id);
               if(moduloBanco == null)
                    throw new Exception("Item não encontrado com o ID fornecido.");
                    
                    moduloBanco.titulo = modulo.titulo;
                    moduloBanco.aulas = modulo.aulas;

                _context.Modulos.Update(moduloBanco);
                _context.SaveChanges();

                return moduloBanco;
        }
        public bool Delete(int id)
        {
            var moduloBanco = _context.Modulos.Find(id);

                if ( moduloBanco == null )
                    throw new Exception("Item não encontrado com o ID fornecido.");

                // var aulasRelacionadas = _context.Aulas.Where(a => a.ModuloId == id).ToList();
                // if (aulasRelacionadas.Any())
                // {
                //     _context.Aulas.RemoveRange(aulasRelacionadas);
                // }   

                _context.Modulos.Remove(moduloBanco);
                _context.SaveChanges();

                return true;
        }
        public Modulo GetById(int id)
        {
           return _context.Modulos.Find(id);
        }
    }
}