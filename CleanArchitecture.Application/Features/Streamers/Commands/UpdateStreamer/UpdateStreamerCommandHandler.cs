using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommandRequest>
    {
        private readonly IBaseRepository<Streamer> _streamerRepository;
        private readonly IMapper _mapper;

        public UpdateStreamerCommandHandler(IBaseRepository<Streamer> streamerRepository, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStreamerCommandRequest request, CancellationToken cancellationToken)
        {
            Streamer streamerToUpdate =  await  _streamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate == null)
            {
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, streamerToUpdate);

            await _streamerRepository.UpdateAsync(streamerToUpdate);

            return Unit.Value;
        }
    }
}
