using System;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly DeedSimpleContext _context;

        public UserRepository()
        {
            _context = new DeedSimpleContext();
        }

        public void AddSellerUser(SellerUser seller)
        {
            _context.SellerUsers.Add(seller);
            _context.SaveChanges();
        }

        public void AddBuyerUser(BuyerUser buyer)
        {
            _context.BuyerUsers.Add(buyer);
            _context.SaveChanges();
        }

        public SellerUser GetSellerUser(string sellerId)
        {
            return _context.SellerUsers.Find(sellerId);
        }

        public BuyerUser GetBuyerUser(string buyerId)
        {
            return _context.BuyerUsers.Find(buyerId);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
