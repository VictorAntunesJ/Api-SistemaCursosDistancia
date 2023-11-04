using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Interfaces;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Repositories
{
    public class AulaRepository : IAulaRepository
    {
        private readonly CursoDistanciaContext _context;
        public AulaRepository(CursoDistanciaContext context)
        {
            _context = context;
        }


         public Aula Insert(int Id, Aula aula)
        {
            _context.Add(aula);
            _context.SaveChanges();
            return aula;
        }






        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Aula> GetALL()
        {
            throw new NotImplementedException();
        }

        public Aula GetBuId(int Id)
        {
            throw new NotImplementedException();
        }

       

        public Aula Update(int ID, Aula aula)
        {
            throw new NotImplementedException();
        }
    }
}