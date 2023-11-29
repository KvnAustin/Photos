using Microsoft.AspNetCore.Mvc;
using Photos.Core.Interfaces;
using Photos.Models;
using Photos.UI.ViewModels;

namespace Photos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhoto _photoService;

        public HomeController(IPhoto photoService)
        {
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var photos = await _photoService.Get();
            var albumIds = _photoService.GetAlbumIds(photos);

            var photoDtos = GetPhotoViewModels(photos);
            var model = new PhotosPageViewModel(photoDtos, albumIds);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Photo(int id)
        {
            var photo = await _photoService.Get(id);
            var albumIds = await _photoService.GetAlbumIds();

            var photoDto = GetPhotoViewModel(photo);
            var model = new PhotoPageViewModel(photoDto, albumIds);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Album(int id)
        {
            var photos = await _photoService.GetByAlbumId(id);
            var albumIds = await _photoService.GetAlbumIds();

            var photoDtos = GetPhotoViewModels(photos);
            var model = new PhotosPageViewModel(photoDtos, albumIds) { AlbumId = id };

            return View(model);
        }

        #region Helper Methods
        private IEnumerable<PhotoViewModel> GetPhotoViewModels(IEnumerable<Photo>? photos)
        {
            if (photos == null)
                return Enumerable.Empty<PhotoViewModel>();

            return photos.Select(photo => GetPhotoViewModel(photo));
        }

        private PhotoViewModel GetPhotoViewModel(Photo? photo)
        {
            if (photo == null)
                return new PhotoViewModel();

            return new PhotoViewModel(
                photo.Id,
                photo.AlbumId,
                photo.Title,
                photo.Url,
                photo.ThumbnailUrl
                );
        }
        #endregion
    }
}