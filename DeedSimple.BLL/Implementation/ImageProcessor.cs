using DeedSimple.BLL.Converters;
using DeedSimple.BLL.Interface;
using DeedSimple.DataAccess;
using DeedSimple.DataAccess.Interface;
using DeedSimple.ViewModel.Image;

namespace DeedSimple.BLL.Implementation
{
    public class ImageProcessor : IImageProcessor
    {
        private readonly IImageRepository _imageRepository;

        public ImageProcessor(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public ViewImageModel GetImage(long imageId)
        {
            return _imageRepository.GetImage(imageId).ToViewImageModel();
        }

        public long AddImage(AddPropertyImageModel image, string fileName, string contentType)
        {
            return _imageRepository.AddImage(image.PropertyId, image.ToImage(fileName, contentType));
        }
    }
}