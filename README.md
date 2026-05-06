🎯 Objetivos
Aplicar conceitos de arquitetura em camadas utilizando DDD
Implementar autenticação segura com JWT
Utilizar Entity Framework Core com migrations
Implementar regras de negócio corretamento ao DD
Aplicar testes unitários utilizando TDD
Demonstrar organização e separação de responsabilidades

🧱 Arquitetura

O projeto está dividido nas seguintes camadas:

FIAPCloudGames
├── API
├── Application
├── Domain
├── Infrastructure
└── Tests

📂 Camadas
API

Responsável pelos controllers, autenticação JWT, Swagger e middleware.

Application

Contém Services, DTOs e regras de aplicação.

Domain

Contém entidades, interfaces, Value Objects, eventos de domínio e regras de negócio.

Infrastructure

Responsável pela persistência de dados, repositories e Entity Framework Core.

Tests

Contém testes unitários aplicando TDD.

🔐 Autenticação

A autenticação é realizada utilizando JWT Bearer Token.

O sistema possui dois perfis:

Admin
Pode criar, editar e deletar jogos e usuários
User
Pode visualizar jogos e atualizar nome de usuário

🗄️ Banco de Dados

O projeto utiliza:

SQL Server
Entity Framework Core
Migrations

🧪 Testes

Foram implementados testes unitários utilizando xUnit e o conceito de TDD.
