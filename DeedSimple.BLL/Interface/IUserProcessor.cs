using DeedSimple.ViewModel.User;

namespace DeedSimple.BLL.Interface
{
    public interface IUserProcessor
    {
        void AddSellerUser(AddUserModel seller);
        void AddBuyerUser(AddUserModel buyer);
        ViewSellerUserModel GetSellerUser(string sellerId);
        ViewBuyerUserModel GetBuyerUser(string buyerId);
    }
}