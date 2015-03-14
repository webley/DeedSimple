using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public interface IImageRepository
    {
        Image GetImage(long imageId);
        long AddImage(long propertyId, Image image);
    }
}