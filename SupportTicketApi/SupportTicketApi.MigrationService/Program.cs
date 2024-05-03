using SupportTicketApi.Data;
using SupportTicketApi.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<ApiDbInitializer>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(ApiDbInitializer.ActivitySourceName));

builder.AddSqlServerDbContext<TicketContext>("sqldata");

var host = builder.Build();
host.Run();
