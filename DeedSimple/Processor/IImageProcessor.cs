using DeedSimple.Domain;

namespace DeedSimple.Processor
{
    public interface IImageProcessor
    {
        Image GetImage(long imageId);
        long AddImage(Image image);
    }
}