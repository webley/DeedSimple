using System.Collections.Generic;
using DeedSimple.Domain;
using PagedList;

namespace DeedSimple.Processor
{
    public interface IPropertyProcessor
    {
        Property GetProperty(long propertyId);
        IEnumerable<Property> GetPropertiesFiltered(PropertySortOrder sortOrder, string searchString);
        List<Property> GetPropertiesForUser(string userId);
        List<Offer> GetOffersForBuyer(string buyerUserId);
        Offer GetOffer(long offerId);
        List<Offer> GetOffersForSeller(string sellerUserId);
        long AddPropertyForUser(string userId, Property property);
        long PlaceOfferForProperty(string userId, Offer offer);
        bool PropertyCanBeEditedByUser(long propertyId, string userId);

        void CancelOffer(long offerId);
        void AcceptOffer(long offerId);
        void RejectOffer(long offerId);
    }
}