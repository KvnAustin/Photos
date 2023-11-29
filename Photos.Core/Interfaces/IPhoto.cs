using Photos.Models;

namespace Photos.Core.Interfaces
{
    public interface IPhoto
    {
        Task<IEnumerable<Photo>> Get();

        Task<Photo> Get(int id);

        Task<IEnumerable<Photo>> GetByAlbumId(int albumId);

        Task<IEnumerable<int>> GetAlbumIds();

        IEnumerable<int> GetAlbumIds(IEnumerable<Photo> photos);
    }
}
