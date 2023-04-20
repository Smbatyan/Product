using FastEndpoints;
using FastEndpoints.Swagger;
using Product.API.Extensions;
using Product.API.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddHelpers();
builder.Services.AddConfigurationSettings(builder.Configuration);

builder.AddAuth();

builder.Services.AddAuthorization();

WebApplication app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.UseAuthentication();
app.UseAuthorization();

app.Run();