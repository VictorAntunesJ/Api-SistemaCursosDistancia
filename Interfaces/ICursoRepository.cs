using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Interfaces
{
    public interface ICursoRepository
    {
        //CRUD
        //Read
        ICollection<Curso> GetALL();
        Curso GetBuId(int Id);
        // Create
        Curso Insert(int Id, Curso curso);
        //Update
        Curso Update (int ID, Curso curso);
        //Delete
        bool Delete (int Id);
    }
}