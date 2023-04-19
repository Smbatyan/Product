using FastEndpoints;
using FastEndpoints.Swagger;
using Product.API.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

WebApplication app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();