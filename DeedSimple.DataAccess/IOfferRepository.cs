using System.Collections.Generic;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public interface IOfferRepository
    {
        List<Offer> GetOffersForProperty(long propertyId);
        List<Offer> GetOffersForBuyer(string buyerId);
    }
}
