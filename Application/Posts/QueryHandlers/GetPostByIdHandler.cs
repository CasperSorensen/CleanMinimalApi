using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers;

public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
{
    private readonly IStorage _dbRepository;

    public GetPostByIdHandler(IStorage dbRepository)
    {
        _dbRepository = dbRepository;
    }

    public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
    {
        return await _dbRepository.GetPostById(request.PostId);
    }
}