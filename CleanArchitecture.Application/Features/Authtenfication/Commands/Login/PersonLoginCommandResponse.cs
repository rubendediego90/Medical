using CleanArchitecture.Domain.Model;

namespace CleanArchitecture.Application.Features.Authtenfication.Commands.Login
{
    public class PersonLoginCommandResponse
    {
        public Person person { get; set; } = null!;
        public string Token { get; set; } = null!;
       
    }
}
