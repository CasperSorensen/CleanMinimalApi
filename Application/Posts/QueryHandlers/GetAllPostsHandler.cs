using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandlers;

public class GetAllPostsHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
{
    private readonly IStorage _dbRepository;

    public GetAllPostsHandler(IStorage dbRepository)
    {
        _dbRepository = dbRepository;
    }

    public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
    {
        return await _dbRepository.GetAllPosts();
    }
}