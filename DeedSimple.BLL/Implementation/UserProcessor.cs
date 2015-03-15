using System.Linq;
using DeedSimple.BLL.Converters;
using DeedSimple.BLL.Interface;
using DeedSimple.DataAccess;
using DeedSimple.DataAccess.Interface;
using DeedSimple.ViewModel.User;

namespace DeedSimple.BLL.Implementation
{
    public class UserProcessor : IUserProcessor
    {
        private readonly IUserRepository _userRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IPropertyRepository _propertyRepository;

        public UserProcessor(IUserRepository userRepository, IOfferRepository offerRepository, IPropertyRepository propertyRepository)
        {
            _userRepository = userRepository;
            _offerRepository = offerRepository;
            _propertyRepository = propertyRepository;
        }

        public void AddUser(AddUserModel seller)
        {
            _userRepository.AddUser(seller.ToUser());
        }

        public ViewSellerUserModel GetSellerUser(string sellerId)
        {
            var properties = _propertyRepository
                .GetPropertiesBySellerId(sellerId)
                .Select(prop => prop.ToViewPropertyDetailsModel());

            return _userRepository.GetUser(sellerId).ToViewSellerUserModel(properties.ToList());
        }

        public ViewBuyerUserModel GetBuyerUser(string buyerId)
        {
            var offers = _offerRepository
                .GetOffersForBuyer(buyerId)
                .Select(offer =>
                {
                    var property = _propertyRepository.GetProperty(offer.PropertyId);
                    return offer.ToViewOfferModel(property.Images.FirstOrDefault(), property.TagLine);
                });

            return _userRepository.GetUser(buyerId).ToViewBuyerUserModel(offers.ToList());
        }
    }
}