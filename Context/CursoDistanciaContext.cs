using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_SistemaCursosDistancia.Context
{
    public class CursoDistanciaContext: DbContext
    {
       public CursoDistanciaContext(DbContextOptions<CursoDistanciaContext> options) :base(options)
        {

        }

        public DbSet<Cadastro> Cadastros {get; set;}
        public DbSet<Aula> Aulas {get; set;}
        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Modulo> Modulos {get; set;}
    }
}