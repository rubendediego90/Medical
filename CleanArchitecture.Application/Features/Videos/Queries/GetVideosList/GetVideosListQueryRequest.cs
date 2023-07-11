using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryRequest : IRequest<List<GetVideosListQueryResponse>>
    {
        public string _Username { get; set; } = String.Empty;

    }
}
