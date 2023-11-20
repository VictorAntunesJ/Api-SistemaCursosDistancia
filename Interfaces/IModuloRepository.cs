using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Interfaces
{
    public interface IModuloRepository
    {
         //CRUD
        //Read
        ICollection<Modulo> GetALL();
        Modulo GetById(int Id);
        // Create
        Modulo Insert(int Id, Modulo modulo);
        //Update
        Modulo Update (int Id, Modulo modulo);
        //Delete
        bool Delete (int Id);
    }
}