using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Interfaces
{
    public interface IAulaRepository
    {
        //CRUD
        //Read
        ICollection<Aula> GetALL();
        Aula GetById(int id);
        // Create
        Aula Insert(int id, Aula aula);
        //Update
        Aula Update (int id, Aula aula);
        //Delete
        bool Delete (int id);
    }
}