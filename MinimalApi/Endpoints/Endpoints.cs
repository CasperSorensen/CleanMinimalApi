using Application.Posts.Queries;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;
using MinimalApi.Abstractions;
using System.Runtime.CompilerServices;

namespace MinimalApi.Endpoints;

public class Endpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("/api/post/{id}", GetPostById).WithName("GetPostById");

        app.MapPost("/api/posts", CreatePost).WithName("CreatePost");
    }

    private async Task<IResult> CreatePost(IMediator mediator, Post newPost)
    {
        var CreatePost = new CreatePost { PostContent = newPost.Content };
        var result = await mediator.Send(CreatePost);
        return Results.Created();
    }

    private async Task<IResult> GetPostById(IMediator mediator, int id)
    {
        var getPost = new GetPostById { PostId = id };
        var post = await mediator.Send(getPost);
        if (post == null) return Results.NoContent();
        return TypedResults.Ok(post);
    }
}