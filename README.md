# EasyMaster

API para mestres de RPG de mesa cadastrarem **sistemas de regras**, seus **módulos** e **componentes**, e os **personagens** de cada campanha. Feita em ASP.NET Core 8 com Entity Framework Core e SQL Server.

> Projeto pessoal em andamento (abril/2025). A ideia é ser o back-end de uma ferramenta que facilite a vida do mestre durante a sessão.

## Modelo

```
Sistema ─┬─ N Módulo ── N Componente
         └─ N Personagem ── N Módulo
```

- **Sistema**: o sistema de regras (por exemplo, D&D, Tormenta, um sistema próprio)
- **Módulo**: um bloco de regras do sistema, do tipo `Matemático` (atributos com valor) ou `Descritivo` (texto)
- **Componente**: item de um módulo, com nome, descrição e valor
- **Personagem**: nome, descrição, lore e os módulos que usa

## Endpoints

Cada recurso tem CRUD completo:

| Recurso | Rotas |
| --- | --- |
| Sistemas | `GET/POST /Sistema` · `GET/PUT/DELETE /Sistema/{id}` |
| Módulos | `GET/POST /Modulo` · `GET/PUT/DELETE /Modulo/{id}` |
| Componentes | `GET/POST /Componente` · `GET/PUT/DELETE /Componente/{id}` |
| Personagens | `GET/POST /Personagem` · `GET/PUT/DELETE /Personagem/{id}` |

## Arquitetura

```
Controllers → Services (App/) → Repositórios → ApplicationDbContext (EF Core)
```

Controllers trabalham com ViewModels; serviços e repositórios ficam atrás de interfaces registradas na injeção de dependência.

## Tecnologias

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core 9 (SQL Server) com migrations
- Swashbuckle (Swagger)

## Como executar

Pré-requisitos: SDK do .NET 8 e SQL Server (vem configurado para o LocalDB).

1. Se precisar, ajuste a connection string `DefaultConnection` em `EasyMaster/appsettings.json`.
2. Crie o banco:
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet ef database update --project EasyMaster
   ```
3. Rode a API e abra o Swagger em `/swagger`:
   ```bash
   dotnet run --project EasyMaster
   ```

---

Feito por **Mikael Francisco** · [Portfólio](https://mikaelfrancisco.vercel.app) · [LinkedIn](https://www.linkedin.com/in/mikael-francisco-a4300b180)
