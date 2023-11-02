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
        Cadastro GetBuId(int Id);
        // Create
        Cadastro Insert(int Id, Cadastro cadastro);
        //Update
        Cadastro Update (int ID, Cadastro cadastro);
        //Delete
        bool Delete (int Id);
    }
}