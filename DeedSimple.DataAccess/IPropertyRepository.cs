using System.Collections.Generic;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public interface IPropertyRepository
    {
        Property GetProperty(long propertyId);
        List<Property> GetProperties(IEnumerable<long> propertyIds);
        List<Property> GetPropertiesBySellerId(string sellerId);
        Offer GetOffer(long offerId);
        List<Offer> GetOffersByBuyerId(string buyerId);
        IEnumerable<Property> GetPropertiesFiltered(PropertySortOrder sortOrder, string searchString);
        long AddPropertyForUser(string sellerId, Property property);
        long PlaceOfferForProperty(string buyerUserId, Offer offer);
        bool PropertyCanBeEditedByUser(long propertyId, string userId);

        void CancelOffer(long offerId);
        void AcceptOffer(long offerId);
        void RejectOffer(long offerId);
    }
}