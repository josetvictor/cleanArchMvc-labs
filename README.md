# Clean Arch Mvc Labs

## Overview

Learn time: Revisão dos conceitos de Arquitetura Limpa, implementação de testes unitarios, aplicação do padrão CQRS e MVC e a utilização do Identity para autenticação na camda de apresentação utilizando razor.

## Context 

Esse projeto foi a aplicação pratica dos conceitos abordados no curso do José Macoratti de nome Clean Architecture Essencial - ASP .NET Core com C#. O foco do projeto é abordar os conceitos da arquitetura limpa, porém, também foi abordado a construção de uma camada para realizar testes de unidade da camada de ´Domain´, testando assim a criação dos objetos e seus metodos e validações respectivas.
Após a construção da aplicação na abordagem da arquitetura limpa, foi apresentado ao padrão CQRS onde foi feito uma mudança na abordagem da entidade de Product para a utilização do padrão CQRS por fins didaticos, não era necessario a aplicação ao projeto devido a simples complexidade abordada.
Por fim, na camada de apresentação foi aplicado ao Padrão de arquitetura MVC(Model, View, Controller) para criar as paginas de interação do usuario, onde foi construido na pasta de Views paginas Razor onde podemos realizar todas as funcionalidades CRUD(Create, Read, Update, Delete) construidas nas camadas de negocio da solução e por fim, foi implementado uma autenticação simples utilizando o Identity presando não ferir os conceitos da arquitetura limpa. 

## Key Features

 - .NET 8.0
 - C#
 - XUnit
 - [Identity](https://www.nuget.org/profiles/identity)
 - [AutoMapper](https://docs.automapper.org/en/stable/)
 - [EntityFrameworkCore](https://learn.microsoft.com/pt-br/ef/core/)
 - [MediatR](https://github.com/jbogard/MediatR)
 - [Pattern CQRS](https://martinfowler.com/bliki/CQRS.html)
 - Clean Architecture
 - [Pattern MVC](https://www.geeksforgeeks.org/mvc-design-pattern/)
 - [Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-8.0&tabs=visual-studio)

 
## Compatible IDEs

Tested on:

- VS Code
- VisualStudio 22

## Useful commands

From the terminal/shell/command line tool, use the following commands to build, test and run the API.

- ### Build the project

```shell
dotnet build
```

- ### Run the tests

```shell
dotnet test
```

- ### Run the application

```shell
# Run the application which will be listening on port `5099`.
dotnet run --project ./src/CleanArchMvc.WebUI/CleanArch.Mvc.WebUI.csproj
```
