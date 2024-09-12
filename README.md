# Byte Eats API

## Descrição

Esta é uma API desenvolvida em .NET que implementa operações CRUD básicas. A API é usada para gerenciar pedidos e está configurada para fornecer documentação interativa usando Swagger. O ORM escolhido para comunicação com o banco de dados é o Entity Framework Core.

## Funcionalidades

- **CRUD Completo**: Operações de criação, leitura, atualização e exclusão de produtos, usuários e pedidos.
- **Swagger**: Documentação interativa acessível em `/api/byte-eats/swagger`.
- **ORM**: Entity Framework Core para comunicação com o banco de dados.

## Configuração

1. **Clone o Repositório**

    ```bash
    git clone https://github.com/brunopeternella/byte-eats-api.git
    cd byte-eats-api
    ```

2. **Instale as Dependências**

    ```bash
    dotnet restore
    ```

3. **Configuração do Banco de Dados**

    Para esse projeto, as migrations são executadas automaticamente ao iniciar a aplicação.

4. **Execute a API**

    ```bash
    cd API.ByteEats
    dotnet run
    ```

5. **Acesse a Documentação Swagger**

    Navegue até `http://localhost:5000/swagger` para interagir com a API.

## Estrutura do Projeto

- `Controllers/` - Controladores para gerenciar pedidos.
- `Models/` - Modelos de dados.
- `Data/` - Contexto do banco de dados e configurações do Entity Framework.
- `Migrations/` - Scripts de migração do banco de dados.

## Design Patterns

- **Repository Pattern**: Para abstrair a lógica de acesso a dados.
- **Unit of Work**: Para gerenciar transações e mudanças no banco de dados.

## Publicação

A API está publicada no Azure e acessível em `https://suaapi.azurewebsites.net`.

## Contribuição

Sinta-se à vontade para abrir issues ou pull requests para melhorias.
