using DeedSimple.Domain;
using DeedSimple.ViewModel.Image;

namespace DeedSimple.BLL.Converters
{
    public static class ImageConverterExtensions
    {
        public static Image ToImage(this AddPropertyImageModel model, string fileName, string contentType)
        {
            Image image = new Image
            {
                Caption = model.Caption,
                FileName = fileName,
                ContentType = contentType
            };

            return image;
        }

        public static ViewImageModel ToViewImageModel(this Image imageEntity)
        {
            var model = new ViewImageModel
            {
                Id = imageEntity.Id,
                Caption = imageEntity.Caption,
                FileName = imageEntity.FileName,
                ContentType = imageEntity.ContentType
            };

            return model;
        }
    }
}
