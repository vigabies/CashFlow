# 💰 CashFlow API

API REST para gerenciamento de **despesas e fluxo financeiro**, desenvolvida com **C# e ASP.NET Core**.

## 📌 Sobre o projeto

O CashFlow permite cadastrar e gerenciar despesas, além de gerar relatórios financeiros.

### Funcionalidades

* ➕ Criar despesas
* 📋 Listar despesas
* 🔎 Buscar despesa por ID
* ✏️ Atualizar despesas
* 🗑️ Excluir despesas
* 📄 Gerar relatório em PDF
* 📊 Gerar relatório em Excel

## 🛠️ Tecnologias

* C#
* .NET / ASP.NET Core
* MySQL
* Swagger / OpenAPI
* Postman
* Git / GitHub

## ✨ Features

- **Domain-Driven Design (DDD)**: Estrutura organizada para facilitar a manutenção e evolução da aplicação.
- **Testes de Unidade**: Testes utilizando **FluentAssertions** para garantir o funcionamento da aplicação.
- **Geração de Relatórios**: Exportação das despesas em **PDF e Excel**.
- **RESTful API com Swagger**: Documentação dos endpoints para facilitar o desenvolvimento e os testes.
  
## 🚀 Endpoints

### Expenses

```http
POST   /api/Expenses
GET    /api/Expenses
GET    /api/Expenses/{id}
PUT    /api/Expenses/{id}
DELETE /api/Expenses/{id}
```

### Reports

```http
GET /api/Report/pdf
GET /api/Report/excel
```

## 📖 Swagger

A API possui documentação através do Swagger, permitindo visualizar e testar todos os endpoints.

Após executar o projeto, acesse o endereço local disponibilizado pela aplicação:

## 👩‍💻 Projeto

Projeto desenvolvido para prática de desenvolvimento de **APIs REST com C# e ASP.NET Core**, incluindo integração com banco de dados e geração de relatórios.
