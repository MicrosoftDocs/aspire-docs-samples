using Microsoft.EntityFrameworkCore;
using SupportTicketApi.Data.Contexts;
using SupportTicketApi.Data.Models;
using SupportTicketApi.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHostedService<Worker>();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddSqlServerDbContext<TicketContext>("sqldata", configureDbContextOptions: options =>
{
    options.ConfigureSqlEngine(o => o.MigrationsAssembly("SupportTicketApi.MigrationService"));
    options.UseAsyncSeeding(async (context, _, cancellationToken) =>
    {
        if (context is TicketContext ticketContext &&
            !await ticketContext.Tickets.AnyAsync(cancellationToken))
        {
            ticketContext.Tickets.Add(new SupportTicket
            {
                Title = "Initial Ticket",
                Description = "Test ticket, please ignore."
            });
            await ticketContext.SaveChangesAsync(cancellationToken);
        }
    });
});

var host = builder.Build();
host.Run();