using CleanArchitecture.Application.Features.Persons.Commands.CreatePerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class PersonController : GenericController
    {

        private IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

       /* [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Pagination<GetEmployeeTypeListQueryResponse>>> GetEmployeeTypesSearch([FromQuery] GetEmployeeTypeListQueryRequest request)
        {
            Pagination<GetEmployeeTypeListQueryResponse> result = await _mediator.Send(request);
            return Ok(result);
        }*/

        [HttpPost(Name = "CreatePerson")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int?>> CreatePerson([FromBody] CreatePersonCommandRequest request)
        {
          return await  _mediator.Send(request);
        }
/*
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
*/
    }
}
