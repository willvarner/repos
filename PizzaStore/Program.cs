// is this adding a namespace?
using Microsoft.OpenApi.Models;

// creates a "builder" which is a minimalAPI app tool I guess
var builder = WebApplication.CreateBuilder(args);

// add SwaggerGen() method. It sets up header information on you API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
   {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
   });


// use the builder to create an app Object.
var app = builder.Build();


// enable CORS?
//builder.Services.AddCors(options => {});


app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});


// map a Get request for app. 
app.MapGet("/", () => "Hello World!");


// Use CORS?
//app.UseCors("Some Unique Text");


// run the application. It will run on a random localhost port unless otherwise configured.
app.Run();
