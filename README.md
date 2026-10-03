# API REST de Gestión de Clientes

API REST desarrollada con **C# y ASP.NET Core** para la gestión de clientes,
utilizando **SQL Server y ADO.NET** para el acceso a datos.

## Tecnologías

- C#
- ASP.NET Core
- .NET
- SQL Server
- ADO.NET
- Swagger / OpenAPI
- Vue.js

## Arquitectura

El proyecto esta organizado por capas para separar las responsabilidades:

- Controllers
- Models
- Entities
- Repositories
- Connection
- Utils

## Funcionalidades

- Consulta de clientes
- Consulta de cliente por ID
- Acceso a datos mediante ADO.NET
- Uso de procedimientos almacenados
- Operaciones asíncronas
- API REST
- Documentación y pruebas de endpoints con Swagger/OpenAPI

## Base de datos

La aplicación utiliza **SQL Server** y procedimientos almacenados
para realizar las operaciones de acceso a datos.

## Swagger

La API utiliza Swagger/OpenAPI para documentar y probar los endpoints.

### URL local

```text
https://localhost:7037/swagger/index.html