# Diagrama de Classes  - CD

```mermaid
classDiagram

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

Curso "" -- "" Modulo 
Modulo "" -- "" Aula 

```
```sh
 - Comoda novo projeto

    dotnet new webapi --name Api/SistemaCursosDistancia
    add file readme.md
    add file .gitignore
     
    dotnet tool install --global dotnet-ef
    dotnet tool update --global dotnet-ef

    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package MySql.EntityFrameworkCore
```



```sh
  - add file Models no diretorio do projeto.
  - add class curso dentro da Models com os seguintes atributos:

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


  - add class Modulo dentro da Models com os seguintes atributos:

          class Modulo
          {
              public int Id { get; set; }
              public string Titulo { get; set; }
              public List<Aula> Aulas { get; set; }
          }

   - add class Modulo dentro da Models com os seguintes atributos:

          public class Aula
          {
              public int Id { get; set; }
              public string Titulo { get; set; }
              public string Conteudo { get; set; }
              public string arquivo {get; set;} 
          }

```

## Referencia
```sh
    https://learn.microsoft.com/pt-br/dotnet/framework/data/adonet/
    https://learn.microsoft.com/pt-br/sql/connect/ado-net/sql/?view=sql-server-ver16
```
