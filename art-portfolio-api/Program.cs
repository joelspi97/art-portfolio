using art_portfolio_api.Extensions;
using art_portfolio_api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Extensions
builder.Services.AddApplicationServices(builder.Configuration);
// END Extensions 

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials()
      .WithOrigins("http://localhost:4200");
});

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
