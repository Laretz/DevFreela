# DevFreela
Comandos utilizados


dotnet build
dotnet new sln -n DevFreelas       
dotnet new classlib -n DevFreela.API
dotnet new classlib -n DevFreela.Core
dotnet new classlib -n DevFreela.Application     
dotnet new classlib -n DevFreela.Infrastructure

dotnet sln DevFreelas.sln add DevFreela.Core/DevFreela.Core.csproj
dotnet sln DevFreelas.sln add DevFreela.Infrastructure/DevFreela.Infrastructure.csproj
dotnet sln DevFreelas.sln add DevFreela.Application/DevFreela.Application.csproj
dotnet sln DevFreelas.sln add DevFreela.API/DevFreela.API.csproj



dotnet sln DevFreelas.sln add DevFreela.Infrastructure/DevFreela.Infrastructure.csproj




dotnet add reference ../DevFreela.Core/DevFreela.Core.csproj
dotnet add reference ../DevFreela.Infrastructure/DevFreela.Infrastructure.csproj
dotnet add reference ../DevFreela.Application/DevFreela.Application.csproj



Insfrastructure referencia pro Core
Application referencia pro Core e Infrastructure
Core para nenhum
API referencia para os Core, Instrastructure e Application


-> Persistência com entity framework core 
 >>>> Configuração de Ambiente
    - dotnet tool install --global dotnet-ef (instalação global da ferramenta Entity Framework Core (EF Core))
    - dotnet add package Microsoft.EntityFrameworkCore
    - dotnet add package Microsoft.EntityFrameworkCore.SqlServer ( para instalar os pacotes NuGet do Entity Framework Core.)
    - dotnet add package Microsoft.EntityFrameworkCore.Tools
    Lembrando que é para instalar os pacotes dentro do DevFreelas.Infrastructure e DevFreelas.API

 >>>> Criando DbContext e DbSet
    - A classe da infrastructure DevFreelaDbContext deve herdar DbContext da entityframeworkcore
    - As tabelas agora devem ser representados por DbSet ao inves de listas
    - Configurando as Entidades Para Tabelas (Relacoes, etc) 
    - Refatorar, criando pasta "Configurations" dentro de "Persistence" criando classe ProjectConfigurations(exemplo de entidade) para cada entidade mapeada
    - Cada classe criada deve herdar IEntityTypeConfiguration<Project> (exemplo de entidade) 
    
 >>>> Gerando e Aplicando Migrations 
    - ir até appsettings.json e adicionar connection string:  "DevFreelaCs" : "Server=localhost\\SQLEXPRESS;Database=DevFreela;Trusted_Connection=True; trustServerCertificate=true"
    - ir até program.cs e configurar o EF Core para se conectar ao banco de dados especificado na string de conexão "DevFreelaCs"
    - Criar as migrations, comando: dotnet ef migrations add InitialMigrations -s ../DevFreela.Api/DevFreela.API.csproj -o ./Persistence/Migrations (executar o comando na pasta .Infrastructure)
    - atualizar o banco de dados do projeto com as migrações mais recentes: dotnet ef database update -s ../DevFreela.API/DevFreela.API.csproj 
    - adicionar _dbContext.SaveChanges(); aos metodos do service onde há alterações para persistir no banco de dados
    - utilizar include() no getbyid de project para trazer informação de freelancer + 


-> Command Query Responsibillity Segregation (CQRS)
   - dotnet add package MediatR --version 12.3.0
   - no program.cs, precisa adicionar: builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));
   - Criar as pastas commands com CreateProjects e as classes CreateProjectCommand + CreateProjectCommandHandle
   - pegar os atributos de InputModel e colocar dentro do CreateProjectCommand e ir fazendo um a um todos os comandos
   - pegar o metodo de create e levar para CreateProjectCommandHandler, com isso, agora ao inves de usar inputmodel, usamos request e tambem utilizamos asyn + await
   - no ProjectController, o metodo post deve ter as alterações utilizando mediator.Send() e fazer as alterações para ficar de acordo (Task<iaction>, + comamnd)
   - agora depois de finalizar os command, começar as Query, ir nas interfaces e criar um GetUsers ( criar um para cada consulta, getuser é o unico metodo da IUsersService)
   - apos retirar todos os metodos do service, pode excluir o service e vai apresentar erro no controller, ai substitui onde usa o SkillService  por IMediator
   - Criando query passo a passo
      -> pasta GetProjectByid
         -> Classe GetProjectByidQuery 
            -> GetProjectByidQuery: implementa IRequest com o tipo do metodo na IProjectService  criar atributos que recebe de parametro 

         -> Classe GetProjectByidQueryHandler
            -> GetProjectByidQueryHandler:   implementa IRequestHandler com a query + ProjectDetailsViewModel  
                  implementar interface com metodo do service
                  injeçao de dependencias

      

    

