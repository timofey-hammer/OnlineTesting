using DAL.Contexts;
using Infrastructure.DI;
using Infrastructure.Logger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OnlineTestingDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("OnlineTestingConnection")));

builder.Services.RegisterServices();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = scope.ServiceProvider.GetRequiredService<OnlineTestingDbContext>();
    dbContext.Database.Migrate();
}

app.UseMiddleware<ErrorLoggingMiddleware>(new ConsoleLogger());

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();