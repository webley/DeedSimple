using DeedSimple.DataAccess;
using DeedSimple.Domain;

namespace DeedSimple.Processor
{
    public class ImageProcessor : IImageProcessor
    {
        private readonly IImageRepository _imageRepository;

        public ImageProcessor(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Image GetImage(long imageId)
        {
            return _imageRepository.GetImage(imageId);
        }

        public long AddImage(Image image)
        {
            return _imageRepository.AddImage(image);
        }
    }
}