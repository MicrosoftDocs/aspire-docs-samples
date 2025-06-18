using SupportTicketApi.Data.Contexts;
using SupportTicketApi.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));
builder.AddSqlServerDbContext<TicketContext>("sqldata");

var host = builder.Build();
host.Run();
