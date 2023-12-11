using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers;

public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
{
    private readonly IStorage _dbRepository;

    public UpdatePostHandler(IStorage dbRespository)
    {
        _dbRepository = dbRespository;
    }

    public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        return await _dbRepository.UpdatePost(request.PostContent, request.PostId);
    }
}