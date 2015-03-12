using DeedSimple.DataAccess;
using DeedSimple.Domain;

namespace DeedSimple.Processor
{
    public class UserProcessor : IUserProcessor
    {
        private readonly IUserRepository _userRepository;

        public UserProcessor(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddSellerUser(SellerUser seller)
        {
            _userRepository.AddSellerUser(seller);
        }

        public void AddBuyerUser(BuyerUser buyer)
        {
            _userRepository.AddBuyerUser(buyer);
        }

        public SellerUser GetSellerUser(string sellerId)
        {
            return _userRepository.GetSellerUser(sellerId);
        }

        public BuyerUser GetBuyerUser(string buyerId)
        {
            return _userRepository.GetBuyerUser(buyerId);
        }
    }
}