using DeedSimple.BLL.Converters;
using DeedSimple.BLL.Interface;
using DeedSimple.DataAccess;
using DeedSimple.ViewModel.User;

namespace DeedSimple.BLL.Implementation
{
    public class UserProcessor : IUserProcessor
    {
        private readonly IUserRepository _userRepository;

        public UserProcessor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            return _userRepository.GetBuyerUser(buyerId).ToViewBuyerUserModel(null, null);
        }
    }
}