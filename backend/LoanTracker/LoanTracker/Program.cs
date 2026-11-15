using LoanTracker.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var conStr = builder.Configuration.GetConnectionString("LoanTracker");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LoanTrackerContext>(options =>
    options.UseNpgsql(conStr));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
