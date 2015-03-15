using System.Linq;
using DeedSimple.BLL.Converters;
using DeedSimple.BLL.Interface;
using DeedSimple.DataAccess;
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

        public void AddSellerUser(AddUserModel seller)
        {
            _userRepository.AddSellerUser(seller.ToSellerUser());
        }

        public void AddBuyerUser(AddUserModel buyer)
        {
            _userRepository.AddBuyerUser(buyer.ToBuyerUser());
        }

        public ViewSellerUserModel GetSellerUser(string sellerId)
        {
            return _userRepository.GetSellerUser(sellerId).ToViewSellerUserModel();
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

            return _userRepository.GetBuyerUser(buyerId).ToViewBuyerUserModel(offers.ToList());
        }
    }
}