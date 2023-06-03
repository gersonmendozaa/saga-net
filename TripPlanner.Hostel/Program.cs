using TripPlanner.Hostel.Data;
using TripPlanner.Hostel.Data.Interfaces;
using TripPlanner.Hostel.Repositories;
using TripPlanner.Hostel.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IHostelRepository, HostelRepository>();
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
