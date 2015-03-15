using DeedSimple.Domain;

namespace DeedSimple.DataAccess.Interface
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(string userId);
    }
}