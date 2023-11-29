namespace Photos.UI.ViewModels
{
    public class PhotoPageViewModel : BasePageViewModel
    {
        public PhotoPageViewModel(PhotoViewModel photo, IEnumerable<int> albumIds): base(albumIds)
        {
            this.Photo = photo;
        }

        public PhotoViewModel Photo { get; set; }
    }
}
