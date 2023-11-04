using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Interfaces;
using Api_SistemaCursosDistancia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_SistemaCursosDistancia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AulaController : ControllerBase
    {

         private readonly IAulaRepository _aulaRepository;
        public AulaController(IAulaRepository aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }


        /// <summary>
        /// Cadastrar aula na aplicação.
        /// </summary>
        /// <param name="aula">Dados do usuário.</param>
        /// <returns>Dados do usuário cadastrado</returns>

        [HttpPost]
        public IActionResult Create(Aula aula)
        {
            try
            {
                _aulaRepository.Insert(0, aula);
                return Ok();
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

        // /// <summary>
        // /// Listar todos os dados da aplicação.
        // /// </summary>
        // /// <returns>Todos dados cadastrados.</returns>
        // [HttpGet]
        // public IActionResult Listar()
        // {
        //     try
        //     {
        //         var aula = _context.Aulas.ToList();
        //         if (aula == null || aula.Count == 0)
        //         {
        //             return NotFound("Nenhum usuário cadastrado.");
        //         }

        //         return Ok(aula);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return StatusCode(500, new
        //         {
        //             msg = "Falha na conexão",
        //             erro = ex.Message,
        //         });
        //     }
        // }

        // /// <summary>
        // /// Alterar dados da aula.
        // /// </summary>
        // /// <param name="id"></param>
        // /// <param name="aula">Todas informações de um usuário</param>
        // /// <returns>Usuario Alterado</returns>
        // [HttpPut("{id}")]
        // public IActionResult Atualizar(int id, Aula aula)
        // {
        //     try
        //     {
        //        var aulaBanco = _context.Aulas.Find(id);
        //        if(aulaBanco == null)
        //             return NotFound("Item não encontrado com ID fornecido");
                    
        //             aulaBanco.titulo = aula.titulo;
        //             aulaBanco.conteudo = aula.conteudo;
        //             aulaBanco.arquivo = aula.arquivo;

        //         _context.Aulas.Update(aulaBanco);
        //         _context.SaveChanges();

        //         return Ok(aulaBanco);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return StatusCode(500, new
        //         {
        //             msg = "Falha na conexão",
        //             erro = ex.Message,
        //         });
        //     }
        // }

        // /// <summary>
        // /// Excluir um usuário da aplicação.
        // /// </summary>
        // /// <param name="id">Id do usuário</param>
        // /// <returns>Mensagem de exclusão</returns>
        // [HttpDelete("{id}")]
        // public IActionResult Delete(int id)
        // {
        //     try
        //     {
        //         var aulaBanco = _context.Aulas.Find(id);

        //         if (aulaBanco == null)
        //             return NotFound("Iten não encontrado com ID fornecido.");

        //         _context.Aulas.Remove(aulaBanco);
        //         _context.SaveChanges();

        //         return NoContent();
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return StatusCode(500, new
        //         {
        //             msg = "Falha na conexão",
        //             erro = ex.Message,
        //         });
        //     }
        // }
    }
}
