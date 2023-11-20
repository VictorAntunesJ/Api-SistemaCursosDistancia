using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_SistemaCursosDistancia.Models
{
    public class Curso
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string titulo { get; set; }
        
        [StringLength(50)]
         public string Descricao { get; set; }

        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        
        [StringLength(100)]
        public string  Instrutor { get; set; }
        


        // public List<Modulo> Modulos { get; set; }
    }
}
