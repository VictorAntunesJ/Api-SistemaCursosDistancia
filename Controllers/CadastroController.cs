using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_SistemaCursosDistancia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {

        
        private readonly CursoDistanciaContext _context;
        public CadastroController(CursoDistanciaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Cadastro cadastro)
        {
            _context.Add(cadastro);
            _context.SaveChanges();
            return Ok(cadastro);
        }
    }
}