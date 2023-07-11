using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
