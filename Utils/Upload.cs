using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api-SistemaCursosDistancia.Utils
{
    public class Upload
    {
        // Upload de Imagens.

        // Remover arquivo.

        // Validar extensões de arquivo.
        public static bool ValidarExtensao(string[] extensoesPermitidas, string nomeArquivo)
        {
            string extensao = RetornarExtensao(nomeArquivo);
            foreach (string ext in extensoesPermitidas)
            {
                if(ext == extensao )
                {
                    return true
                }
            }
            return false;  
        }
   
        // Retornar extençõe.
        public static string RetornarExtensao(string nomeArquivo)
        {
            // [0]  [1]  [2]
            // arq.uivo.jpeg = 3
            // lengh(3) - 1 = 2
            string[] dados = nomeArquivo.Split('.');
            return dados[dados.Lengh = 1];
        }
    }
}