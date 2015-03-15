using System.Linq;
using DeedSimple.Domain;
using DeedSimple.ViewModel.Image;
using DeedSimple.ViewModel.Property;
using ModelPropertyType = DeedSimple.ViewModel.Enum.PropertyType;

namespace DeedSimple.BLL.Converters
{
    public static class PropertyConverterExtensions
    {
        public static Property ToProperty(this AddPropertyModel model)
        {
            Property property = new Property
            {
                SellerId = model.SellerId,
                TagLine = model.TagLine,
                Type = (PropertyType)model.Type,
                Description = model.Description,
                AskingPrice = model.AskingPrice,
                Road = model.Road,
                Town = model.Town,
                County = model.County,
                PostCode = model.PostCode
            };

            return property;
        }

        public static EditPropertyModel ToEditPropertyModel(this Property propertyEntity)
        {
            EditPropertyModel model = new EditPropertyModel(propertyEntity.Id)
            {
                SellerId = propertyEntity.SellerId,
                Type = (ModelPropertyType)propertyEntity.Type,
                TagLine = propertyEntity.TagLine,
                Road = propertyEntity.Road,
                Town = propertyEntity.Town,
                County = propertyEntity.County,
                PostCode = propertyEntity.PostCode,
                Description = propertyEntity.Description,
                AskingPrice = propertyEntity.AskingPrice
            };

            return model;
        }

        public static ViewPropertyOverviewModel ToViewPropertyOverviewModel(this Property propertyEntity)
        {
            ViewImageModel imageModel = null;
            if (propertyEntity.Images != null)
            {
                var firstImage = propertyEntity.Images.FirstOrDefault();
                if (firstImage != null)
                    imageModel = firstImage.ToViewImageModel();
            }
            imageModel = imageModel ?? Image.GetDefault().ToViewImageModel();

            var model = new ViewPropertyOverviewModel(propertyEntity.Id)
            {
                TagLine = propertyEntity.TagLine,
                Description = propertyEntity.Description,
                AskingPrice = propertyEntity.AskingPrice,
                MainImage = imageModel
            };

            return model;
        }

        public static ViewPropertyDetailsModel ToViewPropertyDetailsModel(this Property propertyEntity)
        {
            var model = new ViewPropertyDetailsModel(propertyEntity.Id)
            {
                Type = (ModelPropertyType)propertyEntity.Type,
                TagLine = propertyEntity.TagLine,
                Road = propertyEntity.Road,
                Town = propertyEntity.Town,
                County = propertyEntity.County,
                PostCode = propertyEntity.PostCode,
                Description = propertyEntity.Description,
                AskingPrice = propertyEntity.AskingPrice,
                Images = propertyEntity.Images.Select(i => i.ToViewImageModel()).ToList()
            };

            return model;
        }
    }
}
