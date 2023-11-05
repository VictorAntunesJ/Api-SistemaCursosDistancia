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
                return Ok(aula);
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
        /// Listar todos os dados da aplicação.
        /// </summary>
        /// <returns>Todos dados cadastrados.</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
               var aula = _aulaRepository.GetALL().ToList();
                return Ok(aula);
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
        /// <param name="aula">Todas informações de um usuário</param>
        /// <returns>Usuario Alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Aula aula)
        {
            try
            {
              var updateCadastro = _aulaRepository.Update(id, aula);
                return Ok(updateCadastro);
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
                bool exclusaoBemSucedida = _aulaRepository.Delete(id);

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

        //Singleton
        //Opload de Imagens
        
    }
}
