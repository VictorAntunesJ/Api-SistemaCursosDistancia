using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Interfaces;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Repositories
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly CursoDistanciaContext _context;
        public CadastroRepository(CursoDistanciaContext context)
        {
            _context = context;
        }


        public Cadastro Insert(int Id, Cadastro cadastro)
        {
            _context.Add(cadastro);
            _context.SaveChanges();
            return cadastro;
        }

         public ICollection<Cadastro> GetALL()
        {
            throw new NotImplementedException();
        }

        public Cadastro GetBuId(int Id)
        {
           throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Cadastro Update(int ID, Cadastro cadastro)
        {
            throw new NotImplementedException();
        }
    }
}