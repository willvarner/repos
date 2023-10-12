using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaStoreWithEntityFramework.Models;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";


builder.Services.AddEndpointsApiExplorer();


// in memory database
//builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("Items"));


//sqllite database
builder.Services.AddSqlite<PizzaDb>(connectionString);


builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "PizzaStore API",
        Description = "Making the pizzas you love.",
        Version = "v1"
    });
});


var app = builder.Build();

// Configure Swagger and Swagger UI for documentation purposes
app.UseSwagger();


app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

// Wire up CRUD Requests

app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());


app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});

app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));

app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
{
      var pizza = await db.Pizzas.FindAsync(id);
      if (pizza is null) return Results.NotFound();
      pizza.Name = updatepizza.Name;
      pizza.Description = updatepizza.Description;
      await db.SaveChangesAsync();
      return Results.NoContent();
});

app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
{
   var pizza = await db.Pizzas.FindAsync(id);
   if (pizza is null)
   {
      return Results.NotFound();
   }
   db.Pizzas.Remove(pizza);
   await db.SaveChangesAsync();
   return Results.Ok();
});


app.Run();