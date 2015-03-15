using System.Collections.Generic;
using System.Linq;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly DeedSimpleContext _context;

        public OfferRepository(DeedSimpleContext context)
        {
            _context = context;
        }

        public List<Offer> GetOffersForProperty(long propertyId)
        {
            return _context.Offers.Where(offer => offer.PropertyId.Equals(propertyId)).ToList();
        }

        public List<Offer> GetOffersForBuyer(string buyerId)
        {
            return _context.Offers.Where(offer => offer.BuyerId.Equals(buyerId)).ToList();
        }
    }
}
