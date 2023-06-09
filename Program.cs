using Microsoft.EntityFrameworkCore;
using SVA_TraineePortal.Models.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyLocationContext>(opt =>
    opt.UseInMemoryDatabase("TraineePortal"));
builder.Services.AddDbContext<LocationDepartmentContext>(opt =>
    opt.UseInMemoryDatabase("TraineePortal"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
