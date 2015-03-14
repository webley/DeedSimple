using DeedSimple.Domain;

namespace DeedSimple.Processor
{
    public interface IImageProcessor
    {
        Image GetImage(long imageId);
        long AddImage(long propertyId, Image image);
    }
}