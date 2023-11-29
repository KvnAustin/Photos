namespace Photos.UI.ViewModels
{
    public class PhotoViewModel
    {
        public PhotoViewModel()
        {
        }

        public PhotoViewModel(int id, int albumId, string title, string url, string thumbnailUrl)
        {
            this.Id = id;
            this.AlbumId = albumId;
            this.Title = title;
            this.Url = url;
            this.ThumbnailUrl = thumbnailUrl;
        }

        public int Id { get; set; }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}
