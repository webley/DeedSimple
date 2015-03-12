using DeedSimple.Domain;
using DeedSimple.Models.Seller;

namespace DeedSimple.Helpers
{
    public static class MappingExtensions
    {
        public static Property MapToProperty(this AddPropertyModel model)
        {
            Property property = new Property
            {
                TagLine = model.TagLine,
                Type = model.Type,
                Description = model.Description,
                AskingPriceDescription = model.AskingPriceDescription,
                Images = model.Images,
                Road = model.Road,
                Town = model.Town,
                County = model.County,
                PostCode = model.PostCode
            };

            return property;
        }

        public static EditPropertyModel MapToEditPropertyModel(this Property propertyEntity)
        {
            EditPropertyModel model = new EditPropertyModel(propertyEntity.Id)
            {
                Type = propertyEntity.Type,
                TagLine = propertyEntity.TagLine,
                Road = propertyEntity.Road,
                Town = propertyEntity.Town,
                County = propertyEntity.County,
                PostCode = propertyEntity.PostCode,
                Description = propertyEntity.Description,
                AskingPriceDescription = propertyEntity.AskingPriceDescription,
                Images = propertyEntity.Images
            };

            return model;
        }
    }
}