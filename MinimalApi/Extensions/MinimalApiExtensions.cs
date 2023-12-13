using Application.Posts.Commands;
using Application.Posts.Queries;
using DataAccess;
using MediatR;
using MinimalApi.Abstractions;

namespace MinimalApi.Extensions;

public static class MinimalApiExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(typeof(CreatePost));
        builder.Services.AddMediatR(typeof(GetPostById));

        var DataAccessConfiguration = new SqlDataAccessConfiguration();
        DataAccessConfiguration.Configure(builder.Services, builder.Configuration);
    }

    public static void RegisterEndpoints(this WebApplication app)
    {
        var endpointdefinitions = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();

        foreach (var definition in endpointdefinitions)
        {
            definition.RegisterEndpoints(app);
        }
    }

}