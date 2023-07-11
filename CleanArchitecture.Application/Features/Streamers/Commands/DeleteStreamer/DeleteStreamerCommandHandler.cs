using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommandRequest>
    {
        private readonly IBaseRepository<Streamer> _streamerRepository;
        private readonly IMapper _mapper;

        public DeleteStreamerCommandHandler(IBaseRepository<Streamer> streamerRepository, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStreamerCommandRequest request, CancellationToken cancellationToken)
        {
            var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);
            if (streamerToDelete == null)
            {
                throw new NotFoundException(nameof(Streamer), request.Id);      
            }

            await _streamerRepository.DeleteAsync(streamerToDelete);

            return Unit.Value;
        }
    }
}
