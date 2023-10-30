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
    public class ModuloController : ControllerBase
    {
        private readonly CursoDistanciaContext _context;
        public ModuloController(CursoDistanciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cadastrar modulo na aplicação
        /// </summary>
        /// <param name="modulo">Dados do usuário</param>
        /// <returns>Dados do modulos cadastrados</returns>


        [HttpPost]
        public IActionResult Create(Modulo modulo)
        {
            try
            {
                _context.Add(modulo);
                _context.SaveChanges();
                return Ok(modulo);

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
        /// <returns>Dados do modulos cadastrados</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var modulo = _context.Modulos.ToList();
                if (modulo == null || modulo.Count == 0)
                {
                    return NotFound("Nenhum usuário cadastrado.");
                }

                return Ok(modulo);
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
        /// Alterar dados do modulo.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modulo">Todas informações de um modulo.</param>
        /// <returns>Usuario Alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Modulo modulo)
        {
            try
            {
                var moduloBanco = _context.Modulos.Find(id);
                if (moduloBanco == null)
                    return NotFound("Item não encontrado com ID fornecido");

                moduloBanco.titulo = modulo.titulo;
                moduloBanco.aulas = modulo.aulas;

                _context.Modulos.Update(moduloBanco);
                _context.SaveChanges();

                return Ok(moduloBanco);
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
        /// Excluir um modulo da aplicação.
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var moduloBanco = _context.Modulos.Find(id);
                if (moduloBanco == null)
                {
                    return NotFound("Item não encontrado com o ID fornecido.");
                }
                foreach (var aula in moduloBanco.aulas)
                {
                    _context.Remove(aula);
                }
                _context.Modulos.Remove(moduloBanco);
                _context.SaveChanges();
                return Ok("Item excluído com sucesso.");
                //Não consegui eliminar o erro  
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