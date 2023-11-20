using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_SistemaCursosDistancia.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _login;

        public LoginController(ILoginRepository login)
        {
            _login = login;
        }

        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            var logar = _login.Logar(email, senha);
            if (logar == null)
                return Unauthorized();

            return Ok(new { token = logar });
        }
    }
}