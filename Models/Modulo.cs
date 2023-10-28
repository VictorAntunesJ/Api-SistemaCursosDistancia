using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_SistemaCursosDistancia.Models
{
    public class Modulo
    {
       [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string titulo { get; set; }
        public List<Aula> aulas { get; set; }

        

        // [ForeignKey("CursoId")]
        // public int CursoId { get; set; }
        // public Curso Curso { get; set; }
    }
}
