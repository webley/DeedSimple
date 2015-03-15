using System.Collections.Generic;
using DeedSimple.DataAccess.Exceptions;
using DeedSimple.DataAccess.Interface;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess.Implementation
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
                return Image.GetDefault();

            return image;
        }

        public long AddImage(long propertyId, Image image)
        {
            var imageOut = _context.Images.Add(image);
            var property = _context.Properties.Find(propertyId);

            if (property == null)
                throw new EntityNotFoundException(string.Format("Property with ID {0} does not exist.", propertyId));

            if (property.Images == null)
                property.Images = new List<Image>();

            property.Images.Add(imageOut);
            _context.SaveChanges();
            return imageOut.Id;
        }
    }
}
