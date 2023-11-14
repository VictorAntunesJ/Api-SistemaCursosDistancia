using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Controllers;
using Api_SistemaCursosDistancia.Interfaces;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly CursoDistanciaContext _cursoDistanciaContext;
        public LoginRepository(CursoDistanciaContext cursoDistanciaContext)
        {
            _cursoDistanciaContext = cursoDistanciaContext;
        }

        public Cadastro Logar(string email, string senha)
        {
            return _cursoDistanciaContext.Cadastros.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
        }

    }
}