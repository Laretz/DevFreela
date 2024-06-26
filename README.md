# DevFreela
Comandos utilizados


dotnet build
dotnet new sln -n DevFreelas            
dotnet sln DevFreelas.sln add DevFreela.Core/DevFreela.Core.csproj
dotnet sln DevFreelas.sln add DevFreela.Infrastructure/DevFreela.Infrastructure.csproj
dotnet sln DevFreelas.sln add DevFreela.API/DevFreela.API.csproj

dotnet add reference ../DevFreela.Core/DevFreela.Core.csproj

dotnet new classlib -n DevFreela.Infrastructure
dotnet sln DevFreelas.sln add DevFreela.Infrastructure/DevFreela.Infrastructure.csproj

dotnet new classlib -n DevFreela.Application
dotnet sln DevFreelas.sln add DevFreela.Application/DevFreela.Application.csproj
dotnet add reference ../DevFreela.Core/DevFreela.Core.csproj



dotnet add reference ../DevFreela.Infrastructure/DevFreela.Infrastructure.csproj


api deve ter referencia para os 3 outros projetos:
cd api 
dotnet add reference ../DevFreela.Infrastructure/DevFreela.Infrastructure.csproj
dotnet add reference ../DevFreela.Application/DevFreela.Application.csproj


