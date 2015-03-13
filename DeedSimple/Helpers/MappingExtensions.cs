using System.Collections.Generic;
using System.Linq;
using DeedSimple.Domain;
using DeedSimple.Models;
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

        public static EditPropertyModel MapToEditPropertyModel(this Property propertyEntity)
        {
            EditPropertyModel model = new EditPropertyModel(propertyEntity.Id)
            {
                Type = (PropertyTypeModel)propertyEntity.Type,
                TagLine = propertyEntity.TagLine,
                Road = propertyEntity.Road,
                Town = propertyEntity.Town,
                County = propertyEntity.County,
                PostCode = propertyEntity.PostCode,
                Description = propertyEntity.Description,
                AskingPrice = propertyEntity.AskingPrice,
                ImageIds = propertyEntity.ImageIds
            };

            return model;
        }

        public static ViewPropertyOverviewModel MapToViewPropertyOverviewModel(this Property propertyEntity)
        {
            var model = new ViewPropertyOverviewModel(propertyEntity.Id)
            {
                TagLine = propertyEntity.TagLine,
                Description = propertyEntity.Description,
                AskingPrice = propertyEntity.AskingPrice,
                MainImageId = propertyEntity.ImageIds.FirstOrDefault()
            };

            return model;
        }

        public static ViewPropertyDetailsModel MapToViewPropertyDetailsModel(this Property propertyEntity)
        {
            var model = new ViewPropertyDetailsModel(propertyEntity.Id)
            {
                Type = propertyEntity.Type,
                TagLine = propertyEntity.TagLine,
                Road = propertyEntity.Road,
                Town = propertyEntity.Town,
                County = propertyEntity.County,
                PostCode = propertyEntity.PostCode,
                Description = propertyEntity.Description,
                AskingPrice = propertyEntity.AskingPrice,
                ImageIds = propertyEntity.ImageIds
            };

            return model;
        }
    }
}