using Npgsql;
using Microsoft.EntityFrameworkCore;
using oPlan_Repository;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OPlanDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});
var app = builder.Build();

app.UseHttpsRedirection();
app.Run();