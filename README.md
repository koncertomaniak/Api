# Koncertomaniak API

REST API built using a modular monolith architecture

## How to run

### Linux/WSL

```bash
$ sh scripts/dev_tools.sh
$ sh scripts/migration.sh
$ dotnet restore
$ dotnet build --no-restore
$ dotnet run -p ./src/Bootstrapper/Koncertomaniak.Api.Bootstrapper
```

### Docker

```bash
$ docker compose -f docker-compose.dev.yml up -d
```

## Run tests

```bash
$ sh scripts/dev_tools.sh
$ sh scripts/migration.sh
$ dotnet restore
$ dotnet build --no-restore
$ dotnet test --no-restore --no-build -e ASPNETCORE_ENVIRONMENT='test'
```