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
    public class ModuloController : ControllerBase
    {
       private readonly IModuloRepository _moduloRepository;
        public ModuloController(IModuloRepository moduloRepository)
        {
            _moduloRepository = moduloRepository;
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
                _moduloRepository.Insert(0, modulo);
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
               var modulo = _moduloRepository.GetALL().ToList();
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
                var updateModulo = _moduloRepository.Update(id, modulo);
                return Ok (updateModulo);
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
               bool exclusaoBemSucedida = _moduloRepository.Delete(id);

                if (exclusaoBemSucedida)
                {
                    return Ok("Usuário deletado com sucesso.");
                }
                else
                {
                    return NotFound("Usuário não encontrado com o ID fornecido.");
                }

            }
            catch (Exception ex)
            {
                // Registre a exceção interna para obter detalhes adicionais.
                Console.WriteLine($"Erro ao excluir o módulo: {ex.InnerException?.Message}");
                throw;
            }
        }
    }
}