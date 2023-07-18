using MediatR;
namespace CleanArchitecture.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandRequest : IRequest<int?>
    {
        public string Password { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string? Name { get; set; }
        public string? LastName1 { get; set; }
        public string? LastName2 { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; } = null!;

    }
}
