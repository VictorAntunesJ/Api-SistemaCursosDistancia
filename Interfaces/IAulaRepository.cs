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
        Aula GetBuId(int Id);
        // Create
        Aula Insert(int Id, Aula aula);
        //Update
        Aula Update (int ID, Aula aula);
        //Delete
        bool Delete (int Id);
    }
}