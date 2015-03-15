using DeedSimple.ViewModel.User;

namespace DeedSimple.BLL.Interface
{
    public interface IUserProcessor
    {
        void AddUser(AddUserModel seller);
        ViewSellerUserModel GetSellerUser(string sellerId);
        ViewBuyerUserModel GetBuyerUser(string buyerId);
    }
}