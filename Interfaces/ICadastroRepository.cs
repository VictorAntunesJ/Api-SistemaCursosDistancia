using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_SistemaCursosDistancia.Models;

namespace Api_SistemaCursosDistancia.Interfaces
{
    public interface ICadastroRepository
    {
        ICollection<Cadastro> GetALL();
        Cadastro GetBuId(int Id);
        Cadastro Insert(int Id, Cadastro cadastro);
        Cadastro Update (int ID, Cadastro cadastro);
        bool Delete (int Id);
    }
}