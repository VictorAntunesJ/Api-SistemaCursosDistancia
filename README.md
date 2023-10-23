# Diagrama de Classes  - CD

```mermaid
classDiagrama

Course --|> Module
Module --|> Classroom

class Course{
  + int Id
  + string Titulo
  + string Descricao
  + DateTime DataInicio
  + DateTime DataFim
  + string Instrutor
  + List<Modulo> Modulos
}

class Module {
  + int Id
  + string Titulo
  + List<Aula> Aulas
}

class Classroom {
  + int Id
  + string Titulo
  + string Conteudo
}