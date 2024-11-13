# ic-tienda


## Construir

dotnet build

## Ejecutar

dotnet run --project=ic_tienda/ic_tienda_presentacion.csproj

## publicar
dotnet publish -c Release
dotnet publish -c Release --project=ic_tienda/ic_tienda_presentacion.csproj

M1M4m#M3M1m4
## Getting started

To make it easy for you to get started with GitLab, here's a list of recommended next steps.

Already a pro? Just edit this README.md and make it your own. Want to make it easy? [Use the template at the bottom](#editing-this-readme)!

# migraciones

## PM
Add-Migration initial
Update-Database

## Dotnet
Compila la solucion (todos los proyectos)
dotnet build

Ejecuto el proyecto que este en la carpeta actual
dotnet run 

Ejectua el proyecto en la carpera especifica
dotnet run --project=ic_tienda\ic_tienda_presentacion.csproj

dotnet ef database update
dotnet ef database update --project=ic_tienda\ic_tienda_presentacion.csproj

dotnet ef migrations add InitialCreate
dotnet ef migrations add initial   --project=ic_tienda\ic_tienda_presentacion.csproj

//add pakages
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.IdentityModel.Tokens

dotnet add package System.IdentityModel.Tokens.Jwt --project=ic_tienda_data\ic_tienda_data.csproj
dotnet add package Microsoft.IdentityModel.Tokens --project=ic_tienda_data\ic_tienda_data.csproj

-- dotnet add package Serilog.Sinks.File 
dotnet add package Serilog.Extensions.Logging.File

--project=ic_tienda_data\ic_tienda_data.csproj