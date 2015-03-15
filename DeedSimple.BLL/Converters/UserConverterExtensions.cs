using System.Linq;
using DeedSimple.Domain;
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

        public static ViewBuyerUserModel ToViewBuyerUserModel(this BuyerUser buyerEntity, Image mainImage, string tagLine)
        {
            var model = new ViewBuyerUserModel
            {
                Id = buyerEntity.Id,
                Offers = buyerEntity.Offers.Select(offer => offer.ToViewOfferModel(mainImage, tagLine)).ToList()
            };

            return model;
        }

        public static ViewSellerUserModel ToViewSellerUserModel(this SellerUser sellerEntity)
        {
            var model = new ViewSellerUserModel
            {
                Id = sellerEntity.Id,
                Properties = sellerEntity.Properties.Select(prop => prop.ToViewPropertyDetailsModel()).ToList()
            };

            return model;
        }
    }
}
