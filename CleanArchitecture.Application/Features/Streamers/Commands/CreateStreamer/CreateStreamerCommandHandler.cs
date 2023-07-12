using AutoMapper;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommandRequest, int>
    {
        private readonly IBaseRepository<Streamer, StreamerDbContext> _streamerRepository;
        private readonly IMapper _mapper;

        public CreateStreamerCommandHandler(IBaseRepository<Streamer, StreamerDbContext> streamerRepository, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateStreamerCommandRequest request, CancellationToken cancellationToken)
        {
            Streamer streamerEntity = _mapper.Map<Streamer>(request);
            Streamer newStreamer = await _streamerRepository.Add(streamerEntity);

            return newStreamer.Id;
        }

    }
}
