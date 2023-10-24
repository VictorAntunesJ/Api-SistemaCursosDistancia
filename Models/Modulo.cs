using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_SistemaCursosDistancia.Models
{
    public class Modulo
    {
        public  int id { get; set; }
        public string titulo { get; set; }
        public List<Aula> aulas { get; set; }
        
    }
}