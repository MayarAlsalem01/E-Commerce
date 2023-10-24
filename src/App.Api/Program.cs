using App.Applcation.Extensions;
using App.Infrastrcuture.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "e-commerce Apis ",
        Version = "v1",
        Description = "A sample API using minimal hosting in ASP.NET Core"
        // You can further customize this with other properties like Contact, License, etc.
    });
});
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}
app.UseCustomExceptionHandler();
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
     );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
