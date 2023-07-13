using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    public class VideoController : GenericController
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetEmployeeTypeListQueryResponse>>> GetVideosByUsername(string username)
        {
            GetEmployeeTypeListQueryRequest query = new()
            {
                username = username
            };
            IEnumerable<GetEmployeeTypeListQueryResponse> videos = await _mediator.Send(query);
            return Ok(videos);
        }
    }

}
