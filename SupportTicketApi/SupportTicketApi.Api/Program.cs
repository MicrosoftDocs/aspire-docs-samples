using SupportTicketApi.Data.Contexts;
using SupportTicketApi.Data.Models;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlServerDbContext<TicketContext>("sqldata");

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //using (var scope = app.Services.CreateScope())
    //{
    //    var context = scope.ServiceProvider.GetRequiredService<TicketContext>();
    //    context.Database.EnsureCreated();

    //    if(!context.Tickets.Any())
    //    {
    //        context.Tickets.Add(new SupportTicket { Title = "Initial Ticket", Description = "Test ticket, please ignore." });
    //        context.SaveChanges();
    //    }
    //}
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
