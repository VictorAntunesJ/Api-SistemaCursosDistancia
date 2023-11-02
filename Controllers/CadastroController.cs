using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// Cadastrar usuário na aplicação
        /// </summary>
        /// <param name="cadastro">Dados do usuário</param>
        /// <returns>Dados do usuário cadastrados</returns>


        [HttpPost]
        public IActionResult Create(Cadastro cadastro)
        {
            try
            {
               _context.Add(cadastro);
                _context.SaveChanges();
                return Ok (cadastro);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Listar todos os dados da aplicação
        /// </summary>
        ///<param>Dados do usuário</param>
        /// <returns>Dados do usuários cadastrados</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var cadastro = _context.Cadastros.ToList();
                if (cadastro == null || cadastro.Count == 0)
                {
                    return NotFound("Nenhum usuário cadastrado.");
                }

                return Ok(cadastro);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        } 

        /// <summary>
        /// Alterar dados da aula.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cadastro">Todas informações de um usuário</param>
        /// <returns>Usuario Alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Cadastro cadastro)
        {
            try
            {
               var cadastroBanco = _context.Cadastros.Find(id);
               if(cadastroBanco == null)
                    return NotFound("Item não encontrado com ID fornecido");
                    
                    cadastroBanco.Nome = cadastro.Nome;
                    cadastroBanco.Email = cadastro.Email;
                    cadastroBanco.Senha = cadastro.Senha;

                _context.Cadastros.Update(cadastroBanco);
                _context.SaveChanges();

                return Ok(cadastroBanco);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }
        /// <summary>
        /// Excluir um usuário da aplicação.
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cadastroBanco = _context.Cadastros.Find(id);

                if (cadastroBanco == null)
                    return NotFound("Iten não encontrado com ID fornecido.");

                _context.Cadastros.Remove(cadastroBanco);
                _context.SaveChanges();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });                
            }
        }
    }
}