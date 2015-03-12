using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public interface IUserRepository
    {
        void AddSellerUser(SellerUser seller);
        void AddBuyerUser(BuyerUser buyer);
        SellerUser GetSellerUser(string sellerId);
        BuyerUser GetBuyerUser(string buyerId);
    }
}