using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(string userId);
    }
}