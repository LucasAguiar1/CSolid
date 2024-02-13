using Domain.Repository;
using Domain.Services;
using Infra.RepositoryCrud;
using Infra.Context;
using Application.Interfaces;
using Application;
using MediatR;
using Domain.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner.
builder.Services.AddControllers();

// Adicione a configuração da injeção de dependência aqui
builder.Services.AddScoped<IClienteRepository, RepositoryCliente>();
builder.Services.AddScoped<IClienteAppService, ClienteAppService>();

builder.Services.AddScoped<IClienteServices, ClienteService>();
builder.Services.AddScoped<ConexaoBanco>();
// Aprenda mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMediatR(typeof(Program).Assembly);

var app = builder.Build();

// Configure o pipeline de solicitações HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
