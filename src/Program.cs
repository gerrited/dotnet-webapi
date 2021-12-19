using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var oltpEndpoint = builder.Configuration.GetValue<string>("OltpEndpoint");

builder.Services.AddOpenTelemetryTracing
(
    builder => 
    {
        builder.SetResourceBuilder
        (
            ResourceBuilder.CreateDefault().AddService("dotnet-webapi")
        ).
        AddAspNetCoreInstrumentation().
        AddOtlpExporter
        (
            opt => { opt.Endpoint = new Uri(oltpEndpoint); }
        );
    }
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
