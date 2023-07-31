using ParkingLots.Api.ApiHandlers;
using ParkingLots.Api.Filters;
using ParkingLots.Api.Middleware;
using FluentValidation;
using ParkingLots.Infrastructure.DataSource;
using ParkingLots.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Elasticsearch;
using Prometheus;
using System.IO;
using ParkingLots.Application.Common.Mapper;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

builder.Services.AddDbContext<DataContext>(opts =>
{    
    var current =  Environment.CurrentDirectory;
    string pathSqlLiteBd = Path.GetFullPath(Path.Combine(current, @"..\"));
    string BDSqlLite = @$"{pathSqlLiteBd}\BDSqlLite";
    string DbPath = System.IO.Path.Join(BDSqlLite, config.GetConnectionString("sqlLiteExample"));
    opts.UseSqlite($"Data Source={DbPath}");    
});

builder.Services.AddHealthChecks()
    .AddDbContextCheck<DataContext>()
    .ForwardToPrometheus();

builder.Services.AddDomainServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.Load("ParkingLots.Application"), typeof(Program).Assembly);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);



builder.Host.UseSerilog((_, loggerConfiguration) =>
    loggerConfiguration
        .WriteTo.Console()
        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(config.GetValue<string>("esUrl")!))
        {
            TypeName = null,
            ModifyConnectionSettings = cx => cx.ServerCertificateValidationCallback((_, _, _, _) => true),
            AutoRegisterTemplate = true,
            IndexFormat = "dotnet-ms-{0:yyyy-MM-dd}",
        }));

SelfLog.Enable(Console.Error);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpMetrics();

app.UseMiddleware<AppExceptionHandlerMiddleware>();

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

app.UseRouting().UseEndpoints(endpoint => {
    endpoint.MapMetrics();
});

app.MapGroup("/api/voter").MapVoter().AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory).WithTags("voter");
app.MapGroup("/api/cells").MapCells().AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory).WithTags("cells");
app.MapGroup("/api/typevehicle").MapTypeVehicle().AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory).WithTags("type vehicle");
app.MapGroup("/api/vehicle").MapVehicle().AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory).WithTags("vehicle");

app.Run();

