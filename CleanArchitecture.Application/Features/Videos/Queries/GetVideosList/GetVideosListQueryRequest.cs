using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryRequest : IRequest<List<GetVideosListQueryResponse>>
    {
        public string username { get; set; } = null!;

    }
}
