
# Aspire docs samples

This repository contains sample projects referenced by the [Aspire documentation](https://aspire.dev).

## SupportTicketApi

A sample Aspire application demonstrating [Entity Framework Core migrations with a separate migration service](https://aspire.dev/integrations/databases/efcore/migrations/). The solution consists of:

| Project | Description |
|---|---|
| **SupportTicketApi.AppHost** | The Aspire orchestrator that wires up SQL Server, the migration service, and the API. |
| **SupportTicketApi.Api** | An ASP.NET Core Web API with CRUD endpoints for support tickets. |
| **SupportTicketApi.MigrationService** | A worker service that applies EF Core migrations and seeds initial data, then exits. |
| **SupportTicketApi.Data** | A shared class library containing the `TicketContext` and `SupportTicket` model. |
| **SupportTicketApi.ServiceDefaults** | Shared Aspire service defaults (health checks, OpenTelemetry, etc.). |

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (for the SQL Server container)
- [Aspire CLI](https://aspire.dev/get-started/install-cli/)

### Running the sample

```bash
aspire run
```

The AppHost will:

1. Start a SQL Server container.
2. Run the **MigrationService** to apply migrations and seed data.
3. Start the **API** only after the migration service completes (`WaitForCompletion`).

### Adding a new migration

```bash
cd SupportTicketApi/SupportTicketApi.MigrationService
dotnet ef migrations add <MigrationName> --startup-project . --project .
```

---

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Legal Notices

Microsoft and any contributors grant you a license to the Microsoft documentation and other content
in this repository under the [Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode),
see the [LICENSE](LICENSE) file, and grant you a license to any code in the repository under the [MIT License](https://opensource.org/licenses/MIT), see the
[LICENSE-CODE](LICENSE-CODE) file.

Microsoft, Windows, Microsoft Azure and/or other Microsoft products and services referenced in the documentation
may be either trademarks or registered trademarks of Microsoft in the United States and/or other countries.
The licenses for this project do not grant you rights to use any Microsoft names, logos, or trademarks.
Microsoft's general trademark guidelines can be found at http://go.microsoft.com/fwlink/?LinkID=254653.

Privacy information can be found at https://privacy.microsoft.com/en-us/

Microsoft and any contributors reserve all other rights, whether under their respective copyrights, patents,
or trademarks, whether by implication, estoppel or otherwise.
