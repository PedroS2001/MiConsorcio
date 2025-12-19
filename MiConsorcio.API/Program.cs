using MediatR;
using MiConsorcio.Application.Interfaces;
using MiConsorcio.Application.UseCases.Consorcio;
using MiConsorcio.Application.UseCases.Expensas;
using MiConsorcio.Application.UseCases.Pagos;
using MiConsorcio.Infrastructure.Persistence;
using MiConsorcio.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiConsorcioDB")));

builder.Services.AddScoped<IConsorcioRepository, ConsorcioRepositoryEF>();

builder.Services.AddScoped<CrearConsorcioHandler>();
builder.Services.AddScoped<CerrarExpensaHandler>();
builder.Services.AddScoped<RegistrarPagoHandler>();

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(CrearConsorcioHandler).Assembly);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});

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
