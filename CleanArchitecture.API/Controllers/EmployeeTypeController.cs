using CleanArchitecture.Application.Features.EmployeeTypes.Commands.CreateEmployeeType;
using CleanArchitecture.Application.Features.EmployeeTypes.Commands.DeleteEmployeeType;
using CleanArchitecture.Application.Features.EmployeeTypes.Commands.UpdateEmployeeType;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class EmployeeTypeController : GenericController
    {

        private IMediator _mediator;

        public EmployeeTypeController(IMediator mediator)
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

        [HttpPost(Name = "CreateEmployeeType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEmployeeType([FromBody] CreateEmployeeTypeCommandRequest request)
        {
          return  await  _mediator.Send(request);
        }

        [HttpPut(Name = "UpdateEmployeeTyper")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEmployeeType([FromBody] UpdateEmployeeTypeCommandRequest request)
        {
            await _mediator.Send(request);

            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteEmployeeType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteEmployeeType(int id)
        {
            DeleteEmployeeTypeCommandRequest command = new()
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
