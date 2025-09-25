using SupportTicketApi.Data.Contexts;
using SupportTicketApi.Data.Models;
using SupportTicketApi.MigrationService;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

// Configure the DbContext with EF 9.0 async seeding
builder.AddSqlServerDbContext<TicketContext>("sqldata", configureDbContextOptions: options =>
{
    options.UseAsyncSeeding(async (context, _, cancellationToken) =>
    {
        if (context is TicketContext ticketContext)
        {
            // Only seed if no tickets exist
            if (!await ticketContext.Tickets.AnyAsync(cancellationToken))
            {
                ticketContext.Tickets.Add(new SupportTicket
                {
                    Title = "Initial Ticket",
                    Description = "Test ticket, please ignore."
                });
                await ticketContext.SaveChangesAsync(cancellationToken);
            }
        }
    });
});

builder.Services.AddHostedService<Worker>();
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

var host = builder.Build();
host.Run();