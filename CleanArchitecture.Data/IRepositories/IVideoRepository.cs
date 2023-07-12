using CleanArchitecture.Domain;
using CleanArchitecture.Domain.IRepositories;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.IRepositories
{
    public interface IVideoRepository : IBaseRepository<Video, StreamerDbContext>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);
        Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
