
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaStoreWithEntityFramework.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("Items"));

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "PizzaStore API",
        Description = "Making the pizzas you love.",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());
app.Run();