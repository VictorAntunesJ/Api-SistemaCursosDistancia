using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Interfaces
{
    public interface ICadastroRepository
    {
        //CRUD
        //Read
        ICollection<Cadastro> GetALL();
        Cadastro GetById(int id);
        // Create
        Cadastro Insert(int id, Cadastro cadastro);
        //Update
        Cadastro Update (int id, Cadastro cadastro);
        //Delete
        bool Delete (int id);
    }
}