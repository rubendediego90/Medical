using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommandRequest>
    {
        private readonly IBaseRepository<Streamer, StreamerDbContext> _streamerRepository;
        private readonly IMapper _mapper;

        public DeleteStreamerCommandHandler(IBaseRepository<Streamer, StreamerDbContext> streamerRepository, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStreamerCommandRequest request, CancellationToken cancellationToken)
        {
            Streamer? streamerToDelete = await _streamerRepository.GetById(request.Id);
            if (streamerToDelete == null)
            {
                throw new NotFoundException(nameof(Streamer), request.Id);      
            }

            await _streamerRepository.Remove(streamerToDelete);
            return Unit.Value;
        }
    }
}
