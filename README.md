# ApiLinkShortener

API simples para encurtamento de URLs, com foco no uso de Docker para orquestração do banco de dados PostgreSQL.

## Tecnologias utilizadas

- .NET 8 Web API
- Entity Framework Core
- PostgreSQL (via Docker)
- Docker e Docker Compose

---

## Como rodar a aplicação

Siga os passos abaixo para clonar o projeto, subir o banco via Docker, aplicar as migrações e executar a API localmente.

### Passo 1 - Clonar o repositório

```bash
git clone https://github.com/talitasdias/ApiLinkShortener.git
cd ApiLinkShortener
```

### Passo 2 - Subir o container do PostgreSQL via Docker Compose

```bash
docker-compose up -d
```

### Passo 3 - Aplicar as migrações no banco

```bash
cd ApiLinkShortener
dotnet ef database update
```

### Rodar a API

```bash
dotnet run
```

### Observações
- Certifique-se de que a porta 5432 do PostgreSQL não esteja sendo usada por outra aplicação para evitar conflitos.
- Caso altere a string de conexão no appsettings.json, ajuste conforme necessário para apontar para o container do PostgreSQL.
- Para parar o container do Docker, execute:
```bash
docker-compose down
```
