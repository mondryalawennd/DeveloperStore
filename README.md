# DeveloperStore API

API desenvolvida em .NET 8 com arquitetura DDD para gerenciamento de vendas, seguindo boas práticas de separação de responsabilidades, CQRS e Entity Framework Core.

---

## 🚀 Tecnologias utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- MediatR (CQRS)
- Docker
- Swagger

---

## 📦 Funcionalidades

A API permite o gerenciamento completo de vendas:

- Criar venda
- Listar vendas
- Buscar venda por ID
- Atualizar venda
- Cancelar/deletar venda
- Aplicação de regras de desconto por quantidade de itens

---

## 📊 Regras de negócio

- Compras com **4 ou mais itens iguais** → 10% de desconto  
- Compras entre **10 e 20 itens iguais** → 20% de desconto  
- **Mais de 20 itens iguais não são permitidos**  
- Compras com menos de 4 itens não recebem desconto  

---

## 🧱 Estrutura do projeto

- Domain → Entidades e regras de negócio
- Application → Casos de uso (CQRS)
- ORM → Entity Framework Core / Repositórios
- WebApi → Controllers e configuração da API

---

## 🐳 Como executar com Docker (PostgreSQL)

### Subir banco de dados:

```bash
docker run --name devstore-postgres \
-e POSTGRES_USER=postgres \
-e POSTGRES_PASSWORD=postgres \
-e POSTGRES_DB=DeveloperEvaluation \
-p 5432:5432 \
-d postgres

## ⚙️ Configuração do projeto

### No arquivo appsettings.json:

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=DeveloperEvaluation;Username=postgres;Password=postgres"
  }
}

## 🗄️ Executar migrations

### dotnet ef database update --project src/Ambev.DeveloperEvaluation.ORM --startup-project src/Ambev.DeveloperEvaluation.WebApi

## ▶️ Executar a aplicação

### dotnet run --project src/Ambev.DeveloperEvaluation.WebApi

## 📍 Endpoints principais

📍 Endpoints principais
Sales
POST /api/sales → Criar venda
GET /api/sales/{id} → Buscar venda
GET /api/sales → Listar vendas
PUT /api/sales/{id} → Atualizar venda
DELETE /api/sales/{id} → Cancelar venda

## 📄 Observações
- A aplicação segue princípios de DDD
- Utiliza padrão CQRS com MediatR
- Regras de desconto aplicadas no domínio
- Eventos de domínio podem ser logados:
- SaleCreated
- SaleUpdated
- SaleCancelled

## ▶️ Executar a aplicação

### dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
