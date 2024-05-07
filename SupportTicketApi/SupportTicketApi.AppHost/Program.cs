var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
                 .AddDatabase("sqldata");

builder.AddProject<Projects.SupportTicketApi_Api>("api")
    .WithReference(sql);

builder.AddProject<Projects.SupportTicketApi_MigrationService>("migrations")
    .WithReference(sql);

builder.Build().Run();
