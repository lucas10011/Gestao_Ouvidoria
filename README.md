# Projeto: Teste Aptidão

Desenvolvimento do projeto para teste de aptidão de um sistema de Gestão de Ouvidoria em Asp.NET MVC & Entity Framework.

## Recursos Utilizados

 * Visual Studio 2017
 * Asp.NET MVC 4;
 * Entity Framework 4;
 * Code First;
 * SQL Server Management 2014;
 * Single Reposity Pattern;
 * Bootstrap 3;
 * .NET Framework 4.5;
 
 ## Execução do Entity Framework nas IDE's: VS 2015/2017:
 
 Ao realizar os comandos:
 
  ```
    Enable-Migrations
  
  ```
  e
  
  ```
    Update-Database -Verbose
  
  ```
  
Nas versões mais recentes do Visual Studio (2015/2017), se faz necessário criar uma nova instância do localdb do sql no seu computador. A qual poderá ser criado da seguinte maneira:

Passo1: Abrir o cmd e executar o seguinte comando:
  ```
  SqlLocalDB.exe create "MSSQLLocalDB"
  
  ```

Passo2: Ir até o 'Package Manager Console' e executar o seguinte comando:
  ```
  Update-Database -Verbose
  
  ```

Ao seguir esses passos, evitará de ocorrer o problema/error 50, de conexão com o SQL Server, erro que evita a criação da tabela via 'Code First' do Entity Framework.
