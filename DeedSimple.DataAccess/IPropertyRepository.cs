using System.Collections.Generic;
using DeedSimple.Domain;

namespace DeedSimple.DataAccess
{
    public interface IPropertyRepository
    {
        List<Property> GetPropertiesBySellerId(string sellerId);
        Property GetProperty(long propertyId);
        List<Property> GetProperties(IEnumerable<long> propertyIds);
        long AddPropertyForUser(string sellerId, Property property);
        long MakeOfferForProperty(string buyerUserId, Offer offer);
        bool PropertyCanBeEditedByUser(long propertyId, string userId);
    }
}