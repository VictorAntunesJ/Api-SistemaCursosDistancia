using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;
        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
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
                _cursoRepository.Insert(0, curso);
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
                var curso = _cursoRepository.GetALL().ToList();
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
                var updateCurso = _cursoRepository.Update(id, curso);
                return Ok (updateCurso);

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
                bool exclusaoBemSucedida = _cursoRepository.Delete(id);

                if (exclusaoBemSucedida)
                {
                    return Ok("Usuário deletado com sucesso.");
                }
                else
                {
                    return NotFound("Usuário não encontrado com o ID fornecido.");
                }
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