using Api_SistemaCursosDistancia.Models;
using Xunit;
namespace TestApi_SistemaCursoDistancia;
public class CadastroTest
{
    [Fact]
    public void DeveRetornarCadastroNotNull()
    {
        // Preparação.
            Cadastro? cadastro;
        // Execução.
            cadastro = new Cadastro();
        // Retorno esperado.
            Assert.NotNull(cadastro);
    }   
    [Fact]
    public void DeveRetornarSoma()
    {
        // Preparação.
        int resultado;
        // Execução.
        resultado = 40+50;
        // Retorno esperado.
        Assert.Equal(90, resultado);
    }
}