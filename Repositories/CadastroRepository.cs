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
            var cadastro  = _context.Cadastros.ToList();
            if(cadastro == null || cadastro.Count == 0)
            {
                return new List<Cadastro>{new Cadastro {Nome = " Nenhum usuário encontrado. "}};
            }
            return cadastro;
        }


          public Cadastro Update(int Id, Cadastro cadastro)
        {
           var cadastroBanco = _context.Cadastros.Find(Id);
                if (cadastroBanco == null)
                     throw new Exception("Item não encontrado com o ID fornecido.");

                cadastroBanco.Nome = cadastro.Nome;
                cadastroBanco.Email = cadastro.Email;
                cadastroBanco.Senha = cadastro.Senha;

                _context.Cadastros.Update(cadastroBanco);
                _context.SaveChanges();

                return cadastroBanco;
        }


        public Cadastro GetBuId(int id)
        {
           return _context.Cadastros.Find(id);
        }

        public bool Delete(int Id)
        {  
            var cadastroBanco = _context.Cadastros.Find(Id);

                if (cadastroBanco == null)
                    throw new Exception("Item não encontrado com o ID fornecido.");

                _context.Cadastros.Remove(cadastroBanco);
                _context.SaveChanges();

                return true;
        }

       
    }
}