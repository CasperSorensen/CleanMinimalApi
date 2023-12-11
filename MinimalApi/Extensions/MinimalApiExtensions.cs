using Application.Posts.Commands;
using Application.Posts.Queries;
using DataAccess;
using MediatR;

namespace MinimalApi.Extensions;

public static class MinimalApiExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        //https://youtu.be/RRrsFE6OXAQ?t=4675
        //var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMediatR(typeof(CreatePost));
        builder.Services.AddMediatR(typeof(GetPostById));

        var DataAccessConfiguration = new SqlDataAccessConfiguration();
        DataAccessConfiguration.Configure(builder.Services, builder.Configuration);
    }

}