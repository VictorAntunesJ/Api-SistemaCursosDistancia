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
    public class CursoController : ControllerBase
    {
        private readonly CursoDistanciaContext _context;
        public CursoController(CursoDistanciaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cadastrar usuário na aplicação
        /// </summary>
        /// <param name="curso">Dados do usuário</param>
        /// <returns>Dados do usuário cadastrados</returns>


        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            try
            {
                _context.Add(curso);
                _context.SaveChanges();
                return Ok(curso);

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
                var curso = _context.Cursos.ToList();
                if (curso == null || curso.Count == 0)
                {
                    return NotFound("Nenhum usuário cadastrado.");
                }

                return Ok(curso);
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
        /// <param name="curso">Todas informações de um usuário</param>
        /// <returns>Usuario Alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Curso curso)
        {
            try
            {
               var cursoBanco = _context.Cursos.Find(id);
               if(cursoBanco == null)
                    return NotFound("Item não encontrado com ID fornecido");
                    
                    cursoBanco.titulo = curso.titulo;
                    cursoBanco.Descricao = curso.Descricao;
                    cursoBanco.dataInicio = curso.dataInicio;
                    cursoBanco.dataFim = curso.dataFim;
                    cursoBanco.Instrutor = curso.Instrutor;

                _context.Cursos.Update(cursoBanco);
                _context.SaveChanges();

                return Ok(cursoBanco);
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
                var cursoBanco = _context.Cursos.Find(id);

                if (cursoBanco == null)
                    return NotFound("Iten não encontrado com ID fornecido.");

                _context.Cursos.Remove(cursoBanco);
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