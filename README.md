# Sistema de Cursos a Distância

Este é o README para o projeto "Sistema de Cursos a Distância". Este projeto é uma API desenvolvida para gerenciar cursos a distância, com cadastros de usuários, cursos, módulos e aulas.


## Diagrama de Classes  - CD

```mermaid
classDiagram

class Cadastro {
  + int Id
  + string Nome
  + string Email
  + DateTime Senha
  + List<Curso> Curso
}

class Curso {
  + int Id
  + string Titulo
  + string Descricao
  + DateTime DataInicio
  + DateTime DataFim
  + string Instrutor
  + List<Modulo> Modulos
}

class Modulo {
  + int Id
  + string Titulo
  + List<Aula> Aulas
}

class Aula {
  + int Id
  + string Titulo
  + string Conteudo
}

Cadastro "" -- "" Curso
Curso "" -- "" Modulo 
Modulo "" -- "" Aula 

```

O diagrama de classes acima representa a estrutura das principais entidades do sistema, incluindo `Cadastro`, `Curso`, `Modulo` e `Aula`.

### Começando

### Configuração do Ambiente de Desenvolvimento

- Crie um novo projeto:

```sh
     dotnet new webapi --name Api/SistemaCursosDistancia
     add file readme.md
     add file .gitignore
```

 - Instale a ferramenta dotnet-ef:

```sh
     dotnet tool install --global dotnet-ef
     dotnet tool update --global dotnet-ef
```

 - Adicione os pacotes do Entity Framework Core:
  
```sh
     dotnet add package Microsoft.EntityFrameworkCore
     dotnet add package Microsoft.EntityFrameworkCore.Design
     dotnet add package Microsoft.EntityFrameworkCore.SqlServer
     dotnet add package Microsoft.EntityFrameworkCore.Tools
```

 - Instale o pacote Microsoft.Data.SqlClient do SQL Server e ADO.NET:

```sh
    dotnet add package Microsoft.Data.SqlClient --version 5.2.0-preview3.23201.1
```

## Modelos

Crie modelos no diretório do projeto. Crie as classes Cadastro, Curso, Modulo e Aula com os seguintes atributos:

```sh
add file Models no diretorio do projeto.
add class Cadastro dentro da Models com os seguintes atributos:

class Cadastro
          {
              public int Id { get; set; }
              public string Nome { get; set; }
              public string email { get; set; }
              public string senha { get; set; }
              public List<Curso> Cursos { get; set; }    
          }

add class curso dentro da Models com os seguintes atributos:

          class Curso
          {
              public int Id { get; set; }
              public string Titulo { get; set; }
              public string Descricao { get; set; }
              public DateTime DataInicio { get; set; }
              public DateTime DataFim { get; set; }
              public string Instrutor { get; set; }
              public List<Modulo> Modulos { get; set; }
          }

add class Modulo dentro da Models com os seguintes atributos:

          class Modulo
          {
              public int Id { get; set; }
              public string Titulo { get; set; }
              public List<Aula> Aulas { get; set; }
          }

add class Modulo dentro da Models com os seguintes atributos:

          public class Aula
          {
              public int Id { get; set; }
              public string Titulo { get; set; }
              public string Conteudo { get; set; }
              public string arquivo {get; set;} 
          }

```

## Banco de Dados (DbContext)

Crie um contexto para o banco de dados, mapeando as entidades para tabelas e estabelecendo a conexão com o banco de dados:

```sh
  add file Context no diretorio do projeto.
  add class CursoDistanciaContext dentro da Context para mapear as entidades do aplicativo para as tabelas do banco de dados e estabelecer a conexão com o banco de dados.

  - `Construtor`
    O construtor do contexto é responsável por configurar a conexão com o banco de dados usando as opções fornecidas durante a injeção de dependência.
 
      public CursoDistanciaContext(DbContextOptions<CursoDistanciaContext> options) :base(options)
      {

      }

      public DbSet<Cadastro> Cadastros {get; set;}
      public DbSet<Aula> Aulas {get; set;}
      public DbSet<Curso> Cursos {get; set;}
      public DbSet<Modulo> Modulos {get; set;}


  - Entidades Mapeadas

    - `Cadastros`: Representa os registros de usuários cadastrados no sistema.
    - `Aulas`: Representa informações sobre as aulas dos cursos, incluindo títulos, conteúdo e arquivos associados.
    - `Cursos`: Representa informações sobre os cursos oferecidos, incluindo títulos, descrições, datas de início e término e   instrutores.
    - `Modulos`: Representa os módulos de um curso, que contêm aulas relacionadas.

```

## ConnectionStrings

Defina as strings de conexão no arquivo de configuração:

```sh
,
  "ConnectionStrings": {
    "ConexaoPadrao":"Server=localhost\\SqlExpress; Initial Catalog=ApiCursoAdistancia;Integrated Security=True; TrustServerCertificate=True"
  }
```

## Configuração do DbContext
```sh
  Nesta parte do código, estamos configurando o contexto do banco de dados para a aplicação. O contexto do banco 
  de dados é uma parte essencial de aplicativos que interagem com bancos de dados SQL. Neste caso, estamos usando 
  o Entity Framework Core para lidar com as operações de banco de dados.

  builder.Services.AddDbContext<MaisEventosVsCodeContextApi>(
      options =>
          options.UseSqlServer(
              builder.Configuration.GetConnectionString("ConexaoPadrao")
          ));
```

## Migrations

Execute as migrações para criar o banco de dados:

```sh
dotnet-ef migrations add ApiCursoDistancia
dotnet-ef database update
```

## Documentacao da API
```sh
Configuração do Swagger.
A configuração do Swagger foi feita da seguinte forma:

- `Título:` Sistema de Cursos a Distância API
- `Versão:` v1
- `Descrição:` API desenvolvida para o site do Sistema de Cursos a Distância.
- `Termos de Serviço:` [Termos de Serviço](https://meusite.com)
- `Contato:` Victor Sérgio, [meusite.com](https://meusite.com)
- ``Licença:` Curso a Distância ApTech, [Detalhes da Licença](https://meusite.com)

Endpoints da API

A API fornece os seguintes endpoints:

- **[GET] /api/cursos**: Retorna a lista de todos os cursos.
- **[GET] /api/cursos/{id}**: Retorna os detalhes de um curso específico.
- **[POST] /api/cursos**: Cria um novo curso.
- **[PUT] /api/cursos/{id}**: Atualiza os detalhes de um curso.
- **[DELETE] /api/cursos/{id}**: Exclui um curso.

Você pode encontrar mais informações sobre cada endpoint, incluindo detalhes dos parâmetros, na documentação interativa do Swagger.

- Como Usar

Aqui você pode fornecer instruções sobre como usar a API. Isso pode incluir exemplos de solicitações, respostas e autenticação, dependendo da complexidade da sua API.
```

## IRepository - Interface de Repositório Genérica 

A `IRepository` é uma interface genérica que define métodos comuns para realizar operações CRUD (Create, Read, Update, Delete) em objetos de diversas classes, incluindo `Cadastro`, `Aula`, `Curso` e `Módulo`, no contexto de um sistema de cursos a distância.

### Métodos Comuns

A interface `IRepository` inclui os seguintes métodos comuns:

- `GetALL()`: Retorna uma coleção de todos os registros do tipo especificado.
- `GetById(int Id)`: Retorna um registro com base no ID especificado.
- `Insert(int Id, T entity)`: Insere um novo registro no repositório.
- `Update(int ID, T entity)`: Atualiza um registro existente com base no ID.
- `Delete(int Id)`: Exclui um registro com base no ID e retorna um valor booleano indicando o sucesso da operação.

### Implementação Específica

A interface genérica `IRepository` pode ser implementada para realizar operações de CRUD em várias classes, incluindo `Cadastro`, `Aula`, `Curso` e `Módulo`. Cada classe específica pode fornecer sua própria implementação da interface, adaptada às suas necessidades.

Isso oferece flexibilidade e reutilização de código ao lidar com diferentes tipos de entidades no sistema de cursos a distância.



## Registro de Serviços (Injeção de Dependência)

```sh
No ASP.NET Core, a injeção de dependência é uma técnica fundamental para gerenciar a resolução de dependências e fornecer objetos de serviço em toda a aplicação. Aqui está um exemplo de como você registra um serviço no contêiner de injeção de dependência no arquivo `Program.cs`:

builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();
```

## Autenticação e Criptografia

```sh
Esta aplicação utiliza um sistema de autenticação seguro para proteger as informações dos usuários. A senha do usuário é armazenada de forma criptografada no banco de dados para garantir a segurança dos dados. Abaixo estão detalhes sobre como a autenticação é implementada:

## Criptografia de Senha

As senhas dos usuários são armazenadas de forma segura usando técnicas de criptografia. Isso significa que, mesmo em caso de violação de dados, as senhas não podem ser facilmente decifradas. A classe `Cadastro` no modelo é responsável por lidar com a criptografia e a comparação de senhas.

## Login

O endpoint de login (`/api/Login`) aceita as credenciais do usuário (email e senha), verifica a autenticidade no banco de dados e retorna um token de autenticação válido em caso de sucesso. Caso as credenciais sejam inválidas, é retornado um status `Unauthorized`.

### Exemplo de Requisição de Login

```http
POST /api/Login
Content-Type: application/json

{
  "email": "usuario@example.com",
  "senha": "senhaSegura123"
}




```

## Adicionando Segurança da Api com JWT - 1º Parte ( - CONFIGURAÇÃO)
 - Instalando bibilhoteca - JWT

```sh
  dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.0
```
# Implementando a conficuração
  No arquivo onde você configura o serviço (Program.cs geralmente), adicione o seguinte código:

```sh
  builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ApiCursoAdistancia-chave-altenticacao")),
        ClockSkew = TimeSpan.FromMinutes(30),
        ValidIssuer = "ApiCursoAdistancia.webAPI",
        ValidAudience = "ApiCursoAdistancia.webAPI",
    };
});
```

## Adicionando Segurança da Api com JWT - 2º Parte(AplicaCão)
    Para garantir que a aplicação retorne um token em vez do cadastro ao realizar o login, 
    é necessário modificar os tipos de retorno dos métodos Logar na classe LoginRepository 
    e na interface ILoginRepository.

 - Modificacações em LoginRepository
```sh
  `Antes:`
      public Cadastro Logar(string email, string senha)


  `Depois:`
      public string Logar(string email, string senha)
      {
          var cadastro = _cursoDistanciaContext.Cadastros.FirstOrDefault(x => x.Email == email);

          if (cadastro != null)
          {
              // Verificar a senha usando BCrypt
              bool confere = BCrypt.Net.BCrypt.Verify(senha, cadastro.Senha);
              if (confere)
              {
                  // Retorna o token ou outra informação necessária
                  return "Token"; // Substituir "Token" pela lógica real de geração do token
              }
          }

          return null;
      }
```

- Modificações em ILoginRepository

```sh
  `Antes:`
    cadastro Logar(string email, string senha);

  `Depois:`
    string Logar(string email, string senha);
```

- Criando credenciais JWT.
    Ao autenticar um usuário, crie as credenciais JWT (claims) da seguinte maneira:

```sh
    var minhasClaims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Email, cadastro.Email),
        new Claim(JwtRegisteredClaimNames.Jti, cadastro.Id.ToString()),
        new Claim(ClaimTypes.Role, "Adm"),
      };
```
- Criando chave de autenticação
  
    A chave de autenticação é uma instância da classe SymmetricSecurityKey e é criada a partir de uma sequência de bytes que representam uma chave secreta.
    no código fornecido, a chave está sendo gerada a partir da representação UTF-8 da string "ApiCursoAdistancia-chave-autenticacao".

```sh
    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ApiCursoAdistancia-chave-autenticacao"));
```

Esta chave é usada em conjunto com o JWT (JSON Web Token) para garantir a autenticidade e integridade das informações trocadas entre a aplicação cliente e a API.
As credenciais são criadas utilizando a chave de autenticação previamente gerada.

```sh
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
```

- Configuração do Token JWT:

O token JWT é configurado com os seguintes parâmetros:
- `Emissor:` (issuer): "ApiCursoAdistancia.webAPI"
- `Audiência:` (audience): "ApiCursoAdistancia.webAPI"
- `Reivindicações:` (claims): Informações específicas do usuário, como email, ID e funções.
- `Data:` de Expiração (expires): Configurada para expirar 30 minutos após a geração.
- `Credenciais:` de Assinatura (signingCredentials): Utiliza as credenciais criadas anteriormente.

```sh
  var meuToken = new JwtSecurityToken(
  issuer: "ApiCursoAdistancia.webAPI",
  audience: "ApiCursoAdistancia.webAPI",
  claims: minhasClaims, 
  expires: DateTime.Now.AddMinutes(30),
  signingCredentials: creds
);
```
- Retorno do Token JWT:
    O token JWT gerado é retornado como uma string.

```sh
  return new JwtSecurityTokenHandler().WriteToken(meuToken);
```      

# Podemos facilmente decodificar um token JWT no site jwt.io para inspecionar as informações contidas no token.

Copie o token JWT gerado durante o login.
[Acesse jwt.io](https://jwt.io/)
Cole o token que foi criado ao fazer o login no campo "Encoded" do site.
O site automaticamente decodificará o token e exibirá as informações nas seções "Header", "Payload" e "Signature".

Você poderá ver as reivindicações (claims) do token, como o email, o identificador do token (Jti), o papel (role),
o cargo, entre outros, dependendo das informações que você incluiu na criação do token. Isso permite que você verifique
se o token gerado está correto e contém as informações esperadas.

# Bloqueio de Acesso a Endpoints com Autorização

Este projeto implementa a autorização para restringir o acesso a determinados endpoints, usando o exemplo do endpoint DELETE na classe CadastroController.

- Configuração na Classe CadastroController
No arquivo CadastroController.cs, adicione a anotação [Authorize] acima da declaração do método 
HttpDelete para restringir o acesso ao endpoint DELETE.

```sh

[Authorize]
[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    // Lógica para excluir o recurso com o ID fornecido
    // ...

    return NoContent(); // 204 No Content
}

```

- Configuração na Classe Program
No arquivo Program.cs, adicione a seguinte linha para habilitar a autorização na aplicação.

```sh
public static void Main(string[] args)
{
    // ...

    app.UseAuthorization();

    // ...
}

```

# Testando a Aplicação com Postman
1. Obtenha o Token de Autenticação:
   -  Use o Swagger para gerar um token de autenticação.
   -  Faça uma requisição POST para a URL de login do Swagger com as credenciais necessárias.
2. Execute uma Requisição DELETE:
   -  No Postman, crie uma requisição DELETE para o endpoint desejado.
   -  Configure a URL da requisição usando o Swagger.
   -  Adicione a autorização passando o token gerado como Bearer Token.
   -  Execute a requisição.

   Exemplo de URL DELETE no Postman:
```sh
  http://localhost:5029/Cadastro/2007

```
   Exemplo de cabeçalho de autorização no Postman:
 ```sh
  Authorization: BearerToken 
  
  Token [seu-token-aqui]

 ```
 
 O retorno esperado é o código de status 204 (No Content), indicando que a operação foi realizada com sucesso.




## Referências

  https://learn.microsoft.com/pt-br/dotnet/framework/data/adonet/
  https://learn.microsoft.com/pt-br/sql/connect/ado-net/sql/?view=sql-server-ver16
  https://www.nuget.org/
  https://learn.microsoft.com/pt-br/ef/

## Contribuições

Você é bem-vindo para contribuir para este projeto. Sinta-se à vontade para abrir problemas (issues) ou enviar solicitações de pull (pull requests) para melhorar esta API.

```sh
  Esta versão do README está organizada em seções claras, utiliza formatação Markdown para destacar código e links, e fornece informações detal
```