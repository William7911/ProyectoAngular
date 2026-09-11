var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options => {
  options.AddPolicy("PermitirAngular", policy => {
    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
  });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// ... (código existente) ...
app.UseCors("PermitirAngular"); // Agregar justo antes de app.MapControllers();

app.MapControllers();

app.Run();
