using CleanArchitecture.Application.Features.EmployeeTypes.Commands.CreateEmployeeType;
using CleanArchitecture.Application.Features.EmployeeTypes.Commands.DeleteEmployeeType;
using CleanArchitecture.Application.Features.EmployeeTypes.Commands.UpdateEmployeeType;
using CleanArchitecture.Application.Features.EmployeeTypes.Queries.GetEmployeeTypesList;
using CleanArchitecture.Application.Services.PaginationService;
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

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<GetEmployeeTypeListQueryResponse>>> GetEmployeeTypesSearch([FromQuery] GetEmployeeTypeListQueryRequest request)
        {
            Pagination<GetEmployeeTypeListQueryResponse> result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost(Name = "CreateEmployeeType")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int?>> CreateEmployeeType([FromBody] CreateEmployeeTypeCommandRequest request)
        {
          return await  _mediator.Send(request);
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
