using DeedSimple.DataAccess.Exceptions;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public class ImageRepository : IImageRepository
    {
        private readonly DeedSimpleContext _context;

        public ImageRepository(DeedSimpleContext context)
        {
            _context = context;
        }

        public Image GetImage(long imageId)
        {
            var image = _context.Images.Find(imageId);
            if (image == null)
                throw new EntityNotFoundException(string.Format("Image with ID {0} does not exist.", imageId));

            return image;
        }

        public long AddImage(Image image)
        {
            return _context.Images.Add(image).Id;
        }
    }
}
