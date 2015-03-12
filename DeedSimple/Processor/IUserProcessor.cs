using DeedSimple.Domain;

namespace DeedSimple.Processor
{
    public interface IUserProcessor
    {
        void AddSellerUser(SellerUser seller);
        void AddBuyerUser(BuyerUser buyer);
        SellerUser GetSellerUser(string sellerId);
        BuyerUser GetBuyerUser(string buyerId);
    }
}