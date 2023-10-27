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

        public DbSet<CadastroCD> CadastroCDs {get; set;}
        public DbSet<AulaCD> AulaCDs {get; set;}
        public DbSet<CursoCD> CursoCDs {get; set;}
        public DbSet<ModuloCD> ModuloCDs {get; set;}
    }
}