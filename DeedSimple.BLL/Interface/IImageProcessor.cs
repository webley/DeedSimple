using DeedSimple.ViewModel.Image;

namespace DeedSimple.BLL.Interface
{
    public interface IImageProcessor
    {
        ViewImageModel GetImage(long imageId);
        long AddImage(AddPropertyImageModel image, string fileName, string contentType);
    }
}