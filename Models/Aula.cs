using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_SistemaCursosDistancia.Models
{
    public class Aula
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public string arquivo {get; set;}
    }
}