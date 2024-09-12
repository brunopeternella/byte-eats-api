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

    Navegue até `http://localhost:5286/api/byte-eats/swagger` para interagir com a API.

## Estrutura do Projeto

Projeto estruturado no formato Domain-Driven Design (DDD).

- `API.ByteEats/` - Ponto de entrada da aplicação: Controllers e Middlewares.
- `API.ByteEats.Domain/` - DTOs, Entidades, Enums, Extensions, Handlers, Interfaces, Models, Services, Validators.
- `API.ByteEats.Infrastructure/` - Contexto do banco de dados, repositórios e scripts de migration.
- `API.ByteEats.Tests/` - Implementação de testes. (Não implementado nesse projeto)

## Design Patterns

- **Repository Pattern**: Para abstrair a lógica de acesso a dados.
- **Unit of Work**: Para gerenciar transações e mudanças no banco de dados.

## Publicação

A API está publicada em minha VPS e acessível em `https://crossnexus.tech/api/byte-eats/swagger/index.html`.

## Pipeline (CI/CD)

É possível analisar o script responsável pelo CI no arquivo `azure-pipelines.yml`, na raiz do projeto.

### CI

#### Estágios

##### Pré Build

- **Job**: `BuildAndTest`
  - **Passos**:
    - Instalar .NET SDK 8.x
    - Restaurar pacotes
    - Compilar projeto (`API.ByteEats.csproj`)
    - Executar testes

##### Build

- **Job**: `DockerBuild`
  - **Passos**:
    - Construir imagem Docker (`byte-eats-api:latest`)
    - Salvar imagem como `byte-eats-api-latest.tar.gz`
    - Publicar artefato Docker como resultado da Run

### CD

O processo de CD é disparado após o artefato (imagem docker) ser gerado pelo CI.

Foram utilizados conceitos simples de publicação no servidor.

- Baixa a imagem do Azure para o Agent
- Carrega o .tar.gz como uma docker image
- Para o container atual
- Remove o container atual
- Sobe um novo container com a nova imagem
