using Npgsql;
using Microsoft.EntityFrameworkCore;
using oPlan_Repository;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Version = "v1",
        Title = "ToDo API",
        Description = "A ASP.NET Core Web API that manages todo entries of many users."
    });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<OPlanDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.Run();