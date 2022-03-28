using UserProductMinimal.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using UserProductMinimal.Interfaces;
using UserProductMinimal.Service;
using UserProductMinimal;
using UserProductMinimal.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI Repository
//builder.Services.AddScoped<IProductRepository, ProductRepository>();

//DI Services
builder.Services.AddScoped<IProductServices, ProductService>();



//builder.Services.AddDbContext<EFContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"))); //Definindo banco
//builder.Services.AddScoped<EFContext, EFContext>();

//ExtensionsMethods
builder.Services.SetCorsConfig();

var app = builder.Build();


//Configurações dos métodos das API's por classes
ProductEndpointsConfig.AddEndpoints(app);



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


