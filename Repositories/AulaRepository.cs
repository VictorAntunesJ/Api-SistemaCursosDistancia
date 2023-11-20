using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Context;
using Api_SistemaCursosDistancia.Interfaces;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Repositories
{
    public class AulaRepository : IAulaRepository
    {
        private readonly CursoDistanciaContext _context;
        public AulaRepository(CursoDistanciaContext context)
        {
            _context = context;
        }

        public Aula Insert(int id, Aula aula)
        {
            _context.Add(aula);
            _context.SaveChanges();
            return aula;
        }

        public ICollection<Aula> GetALL()
        {
            var aula = _context.Aulas.ToList();
            if (aula == null || aula.Count == 0)
            {
                return new List<Aula> { new Aula { titulo = " Nenhum usúario cadastrado. " } };
            }
            return aula;
        }

        public Aula Update(int id, Aula aula)
        {
            var aulaBanco = _context.Aulas.Find(id);
            if (aulaBanco == null)
                throw new Exception("Item não encontrado com o ID fornecido.");

            aulaBanco.titulo = aula.titulo;
            aulaBanco.conteudo = aula.conteudo;
            aulaBanco.arquivo = aula.arquivo;

            _context.Aulas.Update(aulaBanco);
            _context.SaveChanges();

            return aulaBanco;
        }
        public bool Delete(int id)
        {
            var aulaBanco = _context.Aulas.Find(id);

            if (aulaBanco == null)
                throw new Exception("Item não encontrado com o ID fornecido.");

            _context.Aulas.Remove(aulaBanco);
            _context.SaveChanges();

            return true;
        }

        public Aula GetById(int id)
        {
            return _context.Aulas.Find(id);
        }
    }





















}