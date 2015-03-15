using DeedSimple.Domain;

namespace DeedSimple.DataAccess.Interface
{
    public interface IImageRepository
    {
        Image GetImage(long imageId);
        long AddImage(long propertyId, Image image);
    }
}