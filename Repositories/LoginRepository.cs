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
                    return null;
            }
            return null;
        }
    }
}
// //Criar as credenciais do JWT

// //Definimos as Claims
// var minhasClaims = new[]
// {
//     new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
//     new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
//     new Claim(ClaimTypes.Role, "Adm"),

//     new Claim ("Cargo", "Adm")
// };

// //Criando as chaves.
// var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(""))