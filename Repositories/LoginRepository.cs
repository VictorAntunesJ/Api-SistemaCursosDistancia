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
using Microsoft.IdentityModel.Tokens;

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
            var cadastro = _cursoDistanciaContext.Cadastros.FirstOrDefault(x => x.Email == email);
            if (cadastro != null)
            {
                // Verificar a senha usando BCrypt
                if (BCrypt.Net.BCrypt.Verify(senha, cadastro.Senha))
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
                    //Criamos as chaves
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ApiCursoAdistancia-chave-autenticacao"));
                    //Criamos as credenciais 
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    // Geramos o token
                    var meuToken = new JwtSecurityToken(
                        issuer: "ApiCursoAdistancia.webAPI",
                        audience: "ApiCursoAdistancia.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );
                    return new JwtSecurityTokenHandler().WriteToken(meuToken);
                }
            }
            return null;
        }
  }
}
