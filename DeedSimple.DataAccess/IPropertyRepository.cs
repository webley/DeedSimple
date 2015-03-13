using System.Collections.Generic;
using DeedSimple.Domain;
using PagedList;

namespace DeedSimple.DataAccess
{
    public interface IPropertyRepository
    {
        Property GetProperty(long propertyId);
        List<Property> GetProperties(IEnumerable<long> propertyIds);
        List<Property> GetPropertiesBySellerId(string sellerId);
        IEnumerable<Property> GetPropertiesFiltered(PropertySortOrder sortOrder, string searchString);
        long AddPropertyForUser(string sellerId, Property property);
        long MakeOfferForProperty(string buyerUserId, Offer offer);
        bool PropertyCanBeEditedByUser(long propertyId, string userId);
    }
}