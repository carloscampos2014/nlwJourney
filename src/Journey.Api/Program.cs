using FluentValidation;
using Journey.Api.Filters;
using Journey.Application.UseCases.Activities.Delete;
using Journey.Application.UseCases.Activities.GetAll;
using Journey.Application.UseCases.Activities.GetAllByTrip;
using Journey.Application.UseCases.Activities.GetById;
using Journey.Application.UseCases.Activities.Register;
using Journey.Application.UseCases.Activities.Update;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Application.UseCases.Trips.Update;
using Journey.Application.UseCases.Trips.Validators;
using Journey.Communication.Requests;
using Journey.Infrastructure.Context;
using Journey.Infrastructure.Repositories;
using Journey.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Viagens", Version = "v1" });
    // Incluir todos os controladores
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

builder.Services.AddDbContext<JourneyDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("JourneyConnectionString"));
}); 

builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IValidator<RequestRegisterTripJson>, RequestRegisterTripJsonValidator>();
builder.Services.AddScoped<IValidator<RequestRegisterActivityJson>, RequestRegisterActivityJsonValidator>();
builder.Services.AddScoped<IRegisterTripUseCase, RegisterTripUseCase>();
builder.Services.AddScoped<IGetAllTripUseCase, GetAllTripUseCase>();
builder.Services.AddScoped<IGetByIdTripUseCase, GetByIdTripUseCase>();
builder.Services.AddScoped<IDeleteTripUseCase, DeleteTripUseCase>();
builder.Services.AddScoped<IUpdateTripUseCase, UpdateTripUseCase>();
builder.Services.AddScoped<IRegisterActivityUseCase, RegisterActivityUseCase>();
builder.Services.AddScoped<IGetAllActivityUseCase, GetAllActivityUseCase>();
builder.Services.AddScoped<IGetAllByTripActivityUseCase, GetAllByTripActivityUseCase>();
builder.Services.AddScoped<IGetByIdActivityUseCase, GetByIdActivityUseCase>();
builder.Services.AddScoped<IDeleteActivityUseCase, DeleteActivityUseCase>();
builder.Services.AddScoped<IUpdateActivityUseCase, UpdateActivityUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "  API Viagens v1");
        c.DocExpansion(DocExpansion.None); // Exibir o conteúdo expandido por padrão
        c.DefaultModelsExpandDepth(1); // Expandir os modelos por padrão
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();