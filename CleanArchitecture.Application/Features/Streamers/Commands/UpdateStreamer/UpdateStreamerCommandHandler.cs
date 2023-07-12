using AutoMapper;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Infrastructure.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandler : IRequestHandler<UpdateStreamerCommandRequest>
    {
        private readonly IBaseRepository<Streamer, StreamerDbContext> _streamerRepository;
        private readonly IMapper _mapper;

        public UpdateStreamerCommandHandler(IBaseRepository<Streamer, StreamerDbContext> streamerRepository, IMapper mapper)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStreamerCommandRequest request, CancellationToken cancellationToken)
        {
            Streamer? streamerToUpdate =  await  _streamerRepository.GetById(request.Id);

            if (streamerToUpdate == null)
            {
                // throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, streamerToUpdate);

            await _streamerRepository.Update(streamerToUpdate);

            return Unit.Value;
        }
    }
}
