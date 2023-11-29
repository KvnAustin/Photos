namespace Photos.UI.ViewModels
{
    public abstract class BasePageViewModel
    {
        public BasePageViewModel(IEnumerable<int> albumIds)
        {
            this.AlbumIds = albumIds;
        }

        public int AlbumId { get; set; }

        public IEnumerable<int> AlbumIds { get; set; }
    }
}
