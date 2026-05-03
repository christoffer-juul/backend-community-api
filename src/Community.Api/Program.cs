using Community.Api.OpenApi;
using Community.Api.Security;
using Community.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCorsConfiguration();
builder.Services.AddOpenApiConfiguration();

var app = builder.Build();

app.UseCors("All");
app.UseHttpsRedirection();

app.MapOpenApiEndpoints();
app.MapCommunityEndpoints();

app.Run();
