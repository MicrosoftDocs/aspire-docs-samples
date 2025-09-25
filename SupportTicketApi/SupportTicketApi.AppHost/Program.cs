var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql", port: 14329)
                 .WithEndpoint(name: "sqlEndpoint", targetPort: 14330)
                 .AddDatabase("sqldata");

var migration = builder.AddProject<Projects.SupportTicketApi_MigrationService>("migration")
    .WithReference(sql)
    .WaitFor(sql);

builder.AddProject<Projects.SupportTicketApi_Api>("api")
    .WithReference(sql)
    .WaitForCompletion(migration);

builder.Build().Run();
