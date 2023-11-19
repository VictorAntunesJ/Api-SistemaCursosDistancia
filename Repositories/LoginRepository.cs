using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        public string Logar(string email, string senha)
        {
            //return _cursoDistanciaContext.Cadastros.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            // string senhaCriptografada = BCrypt.Net.BCrypt.HashPassword("senha", BCrypt.Net.BCrypt.GenerateSalt(12));

            var cadastro = _cursoDistanciaContext.Cadastros.FirstOrDefault(x => x.Email == email);

            if (cadastro != null)
            {
                // Verificar a senha usando BCrypt
                bool confere = BCrypt.Net.BCrypt.Verify(senha, cadastro.Senha);
                if (confere)
                {
                    // Criar as credenciais do JWT

                    // Definimos as Claims 
                    var minhasClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, cadastro.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, cadastro.Id.ToString()),
                        new Claim(ClaimTypes.Role, "Adm"),

                        new Claim("Cargo", "Adm")
                    };

                    
                }
                    
            }
            return null;
        }
    }
}