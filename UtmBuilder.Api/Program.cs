using UtmBuilder;
using UtmBuilder.Api.Models;
using UtmBuilder.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "My API V1"); });

app.MapPost("/v1/utm", (UtmModel model) =>
    {
        try
        {
            return Results.Ok(new { url = ((Utm)model).ToString() });
        }
        catch (InvalidUtmException ex)
        {
            return Results.BadRequest(new { ex.Message });
        }
        catch
        {
            return Results.BadRequest(new { Message = "Failed to generate UTM" });
        }
    })
    .WithDescription("Generate an UTM based on URL and Metadata")
    .WithSummary("Generate UTM")
    .Produces<Utm>()
    .WithOpenApi();

app.UseSwagger();
app.Run();