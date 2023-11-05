using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_SistemaCursosDistancia.Models
{
    public class Aula
    {
       [Key]
        public int id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string titulo { get; set; }
        
        [StringLength(1000)]
        public string conteudo { get; set; }
        public string arquivo {get; set;}


        

        [ForeignKey("ModuloId")]
        public int ModuloId { get; set; }
        public Modulo Modulo { get; set; }
    }
}