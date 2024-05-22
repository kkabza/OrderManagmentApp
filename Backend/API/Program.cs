using GraphQL.Server.Ui.Voyager;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var AllowSpecificOrigins = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<OMAContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDB");
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//graphQL

builder.Services.AddGraphQLServer()
    .AddQueryType<API.GraphQL.Query>()
    .AddFiltering(); // Add the necessary using statement and package reference for the AddFiltering method.


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseCors("AllowAll");
app.MapGraphQL();
app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions() { GraphQLEndPoint = "/graphql" });
app.Run();

