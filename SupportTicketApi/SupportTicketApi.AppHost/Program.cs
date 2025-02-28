var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql", port: 14329)
                 .WithEndpoint(name: "sqlEndpoint", targetPort: 14330)
                 .AddDatabase("sqldata");

builder.AddProject<Projects.SupportTicketApi_Api>("api")
    .WithReference(sql)
    .WaitFor(sql);

builder.AddProject<Projects.SupportTicketApi_MigrationService>("migrations")
    .WithReference(sql)
    .WaitFor(sql);

builder.Build().Run();
