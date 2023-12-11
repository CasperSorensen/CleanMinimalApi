using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers;

public class DeletePostHandler : IRequestHandler<DeletePost>
{
    private readonly IStorage _dbRepository;

    public DeletePostHandler(IStorage dbRespository)
    {
        _dbRepository = dbRespository;
    }

    public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
    {
        await _dbRepository.DeletePost(request.PostId);
        return Unit.Value;
    }
}