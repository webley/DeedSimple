using System;
using DeedSimple.DataAccess.Interface;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess.Implementation
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly DeedSimpleContext _context;

        public UserRepository()
        {
            _context = new DeedSimpleContext();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(string userId)
        {
            return _context.Users.Find(userId);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
