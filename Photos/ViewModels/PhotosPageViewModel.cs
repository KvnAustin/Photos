namespace Photos.UI.ViewModels
{
    public class PhotosPageViewModel : BasePageViewModel
    {
        public PhotosPageViewModel(IEnumerable<PhotoViewModel> photos, IEnumerable<int> albumIds) : base(albumIds)
        {
            this.Photos = photos;
        }

        public IEnumerable<PhotoViewModel> Photos { get; set; }
    }
}
