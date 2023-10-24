using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_SistemaCursosDistancia.Models
{
    public class Curso
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public string  Instrutor { get; set; }
        public List<Modulo> Modulos { get; set; }
    }
}