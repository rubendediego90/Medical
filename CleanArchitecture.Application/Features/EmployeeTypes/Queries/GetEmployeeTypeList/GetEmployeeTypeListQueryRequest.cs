using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetEmployeeTypeListQueryRequest : IRequest<List<GetEmployeeTypeListQueryResponse>>
    {
        public string username { get; set; } = null!;

    }
}
