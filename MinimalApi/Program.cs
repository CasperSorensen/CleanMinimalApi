using DataAccess;
using Application.Posts.CommandHandlers;
using Application.Posts.QueryHandlers;
using MediatR;
using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(typeof(CreatePost));
builder.Services.AddMediatR(typeof(GetPostById));

var DataAccessConfiguration = new SqlDataAccessConfiguration();
DataAccessConfiguration.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

app.MapGet("/api/post/{id}", async (IMediator mediator, int id) =>
{
    var getPost = new GetPostById { PostId = id };
    var post = await mediator.Send(getPost);
    if (post == null) return Results.NoContent();
    return Results.Ok(post);
}).WithName("GetPostById");

app.MapPost("/api/posts", async (IMediator mediator, Post newPost) =>
{
    var CreatePost = new CreatePost { PostContent = newPost.Content };
    var result = await mediator.Send(CreatePost);
    return Results.Created();
}).WithName("CreatePost");

app.Run();
