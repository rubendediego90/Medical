using MediatR;

namespace CleanArchitecture.Application.Features.Authtenfication.Commands.Login
{
    public class PersonLoginCommandRequest : IRequest<PersonLoginCommandResponse>
    {
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
