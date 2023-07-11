using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IVideoRepository : IBaseRepository<Video>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);
        Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
