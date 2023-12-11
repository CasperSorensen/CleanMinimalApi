using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers;

public class CreatePostHandler : IRequestHandler<CreatePost, Post>
{
    private readonly IStorage _dbRepository;

    public CreatePostHandler(IStorage dbRespository)
    {
        _dbRepository = dbRespository;
    }

    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        var newPost = new Post
        {
            Content = request.PostContent
        };

        return await _dbRepository.CreatePost(newPost);
    }
}