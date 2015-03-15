using System.Collections.Generic;
using System.Linq;
using DeedSimple.Domain;
using DeedSimple.ViewModel.Offer;
using DeedSimple.ViewModel.Property;
using DeedSimple.ViewModel.User;

namespace DeedSimple.BLL.Converters
{
    public static class UserConverterExtensions
    {
        public static BuyerUser ToBuyerUser(this AddUserModel model)
        {
            var user = new BuyerUser
            {
                Id = model.Id
            };

            return user;
        }

        public static SellerUser ToSellerUser(this AddUserModel model)
        {
            var user = new SellerUser
            {
                Id = model.Id
            };

            return user;
        }

        public static ViewBuyerUserModel ToViewBuyerUserModel(this BuyerUser buyerEntity, List<ViewOfferModel> offers)
        {
            var model = new ViewBuyerUserModel
            {
                Id = buyerEntity.Id,
                Offers = offers
            };

            return model;
        }

        public static ViewSellerUserModel ToViewSellerUserModel(this SellerUser sellerEntity, List<ViewPropertyDetailsModel> properties)
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
