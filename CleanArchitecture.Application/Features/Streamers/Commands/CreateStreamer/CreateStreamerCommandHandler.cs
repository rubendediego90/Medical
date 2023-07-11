using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommandRequest, int>
    {
        private readonly IBaseRepository<Streamer> _streamerRepository;
        private readonly IMapper _mapper;

        public CreateStreamerCommandHandler(IBaseRepository<Streamer> streamerRepository, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateStreamerCommandRequest request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

            return newStreamer.Id;
        }

    }
}
