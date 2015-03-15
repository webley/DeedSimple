using System.Collections.Generic;
using DeedSimple.Domain;
using DeedSimple.ViewModel.Offer;
using DeedSimple.ViewModel.Property;
using DeedSimple.ViewModel.User;

namespace DeedSimple.BLL.Converters
{
    public static class UserConverterExtensions
    {
        public static User ToUser(this AddUserModel model)
        {
            var user = new User
            {
                Id = model.Id,
                Type = (UserType)model.Type
            };

            return user;
        }

        public static ViewBuyerUserModel ToViewBuyerUserModel(this User buyerEntity, List<ViewOfferModel> offers)
        {
            var model = new ViewBuyerUserModel
            {
                Id = buyerEntity.Id,
                Offers = offers
            };

            return model;
        }

        public static ViewSellerUserModel ToViewSellerUserModel(this User sellerEntity, List<ViewPropertyDetailsModel> properties)
        {
            var model = new ViewSellerUserModel
            {
                Id = sellerEntity.Id,
                Properties = properties
            };

            return model;
        }
    }
}
