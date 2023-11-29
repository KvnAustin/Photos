using Newtonsoft.Json;
using Photos.Core.Interfaces;
using Photos.Models;
using RestSharp;

namespace Photos.Core.Services
{
    public class PhotoService : IPhoto
    {
        public async Task<IEnumerable<Photo>> Get()
            => await Get("photos");

        public async Task<Photo> Get(int id)
        {
            var photos = await Get($"photos?id={id}");
            if (photos == null)
                return null;

            return photos.FirstOrDefault();
        }

        public async Task<IEnumerable<Photo>> GetByAlbumId(int albumId)
            => await Get($"photos?albumId={albumId}");

        public async Task<IEnumerable<int>> GetAlbumIds()
        {
            var photos = await Get("photos");

            return (photos ?? Enumerable.Empty<Photo>())
                .Select(x => x.AlbumId)
                .Distinct();
        }

        public IEnumerable<int> GetAlbumIds(IEnumerable<Photo> photos)
            => GetAlbumIdsFromPhotos(photos);

        #region Helper Methods

        private async Task<IEnumerable<Photo>> Get(string resource)
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest(resource);

            var response = await client.GetAsync(request);
            if (response?.IsSuccessful == true)
                return JsonConvert.DeserializeObject<IEnumerable<Photo>>(
                    response.Content,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    });

            return null;
        }

        private IEnumerable<int> GetAlbumIdsFromPhotos(IEnumerable<Photo> photos)
            => (photos ?? Enumerable.Empty<Photo>())
                .Select(photo => photo.AlbumId)
                .OrderBy(albumId => albumId)
                .Distinct();

        #endregion
    }
}
