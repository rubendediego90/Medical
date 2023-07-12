using AutoMapper;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.IRepositories;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQueryRequest, List<GetVideosListQueryResponse>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<GetVideosListQueryResponse>> Handle(GetVideosListQueryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Video> videoList = await _videoRepository.GetVideoByUsername(request.username);

            return _mapper.Map<List<GetVideosListQueryResponse>>(videoList);
        }
    }
}
