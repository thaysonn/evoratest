# 🍞 Padaria WebAPI

API REST desenvolvida em .NET para gerenciamento completo de produtos e pedidos de uma padaria, utilizando arquitetura limpa e padrões modernos de desenvolvimento.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias](#tecnologias)
- [Arquitetura](#arquitetura)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Configuração](#configuração)
- [Testando a API](#testando-a-api)

---

## 🎯 Sobre o Projeto

Sistema de gerenciamento de padaria que permite controlar:
- ✅ **Produtos**: Cadastro, edição, consulta e exclusão de produtos
- ✅ **Pedidos**: Criação de pedidos, adição/remoção de produtos e controle de status
- ✅ **Estoque**: Controle automático de estoque ao realizar pedidos

---

## 🚀 Tecnologias

- **.NET 10** - Framework principal
- **ASP.NET Core Web API** - Framework para criação de APIs RESTful
- **Entity Framework Core** - ORM para acesso a dados
- **SQL Server** - Banco de dados relacional
- **MediatR** - Implementação do padrão CQRS e Mediator

---

## 🏗️ Arquitetura

O projeto segue os princípios da **Clean Architecture** e está organizado em camadas:

### Camadas

```
┌─────────────────────────────────────┐
│      Padaria.Webapi (API)          │  ← Controllers, Program.cs
├─────────────────────────────────────┤
│   Padaria.Application (Casos de    │  ← Commands, Queries, Handlers
│         Uso)                        │
├─────────────────────────────────────┤
│   Padaria.Domain (Entidades)       │  ← Produto, Pedido, Usuário
├─────────────────────────────────────┤
│   Padaria.Infrastructure (Dados)   │  ← DbContext, Repositórios
└─────────────────────────────────────┘
```

### Padrões Utilizados

- **CQRS (Command Query Responsibility Segregation)**: Separação entre operações de leitura e escrita
- **Mediator Pattern**: Desacoplamento entre controladores e lógica de negócio
- **Repository Pattern**: Abstração da camada de dados
- **Dependency Injection**: Inversão de controle e gerenciamento de dependências

---

## 📦 Estrutura do Projeto

```
Padaria/
│
├── Padaria.Webapi/                    # Camada de apresentação (API)
│   ├── Controllers/
│   │   ├── ProdutoController.cs       # Endpoints de produtos
│   │   ├── PedidoController.cs        # Endpoints de pedidos
│   │   └── UsuarioController.cs       # Endpoints de usuários
│   ├── Program.cs                     # Configuração da aplicação
│   └── Padaria.Webapi.http           # Arquivo de testes HTTP
│
├── Padaria.Application/               # Camada de aplicação
│   ├── Features/
│   │   ├── Produto/
│   │   │   ├── Commands/
│   │   │   │   ├── CadastrarProdutoCommand.cs
│   │   │   │   ├── EditarProdutoCommand.cs
│   │   │   │   └── ExcluirProdutoCommand.cs
│   │   │   └── Queries/
│   │   │       └── GetProdutoByIdQuery.cs
│   │   └── Pedido/
│   │       ├── Commands/
│   │       │   ├── CadastrarPedidoCommand.cs
│   │       │   ├── IncluirProdutoPedidoCommand.cs
│   │       │   ├── AlterarQtdProdutoPedidoCommand.cs
│   │       │   └── RemoverProdutoPedidoCommand.cs
│   │       └── Queries/
│   │           └── GetPedidoByIdQuery.cs
│   ├── Interfaces/
│   │   └── IApplicationDbContext.cs
│   └── Extensions/
│       └── ServicesCollection.cs      # Configuração do MediatR
│
├── Padaria.Domain/                    # Camada de domínio
│   └── Entities/
│       ├── BaseEntity.cs              # Entidade base
│       ├── Produto.cs                 # Entidade de produto
│       ├── Pedido.cs                  # Entidade de pedido
│       ├── Usuario.cs                 # Entidade de usuário
│       ├── Permissao.cs               # Entidade de permissão
│       └── UsuarioPermissao.cs        # Relação usuário-permissão
│
└── Padaria.Infrastructure/            # Camada de infraestrutura
    └── Persistence/
        └── ApplicationDbContext.cs    # Contexto do Entity Framework
```

---

## ⚙️ Configuração

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) ou SQL Server Express
- IDE recomendada: [Visual Studio 2026](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/thaysonn/evoratest.git
   cd Padaria
   ```

2. **Configure a string de conexão**
   
   Edite o arquivo `appsettings.json` em `Padaria.Webapi`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=PadariaDB;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```
 
---

## 🧪 Testando a API

Este repositório inclui o arquivo `Padaria.Webapi.http`, que permite testar a API rapidamente sem precisar de Postman/Insomnia.

### Como usar o `Padaria.Webapi.http`

1. **Inicie a aplicação**
   - Visual Studio: execute o projeto `Padaria.Webapi` (F5 ou Ctrl+F5)
   - CLI: na raiz do repositório, execute:
     ```bash
     dotnet run --project Padaria.Webapi
     ```

2. **Abra o arquivo de requisições**
   - Visual Studio 2022+/Visual Studio 2026: abra `Padaria.Webapi/Padaria.Webapi.http`
   - VS Code: instale a extensão **REST Client** e abra `Padaria.Webapi/Padaria.Webapi.http`

3. **Ajuste a URL base (se necessário)**
   No início do arquivo, confira a variável `@Padaria_Webapi_HostAddress` (ou similar) e atualize a porta conforme a aplicação estiver rodando (veja a saída do console).

4. **Envie as requisições**
   - Visual Studio: clique em **Send Request** acima de cada requisição
   - VS Code (REST Client): clique em **Send Request** acima de cada requisição

### Fluxo sugerido de testes

- Consultar endpoints básicos
- Criar um **produto**
- Consultar o **produto** por id
- Criar um **pedido** e incluir/remover produtos

Os exemplos já disponíveis no `Padaria.Webapi.http` servem como ponto de partida. Basta executar a aplicação e ir disparando as requisições na ordem desejada.
