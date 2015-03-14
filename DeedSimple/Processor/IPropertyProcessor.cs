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
        long AddPropertyForUser(string userId, Property property);
        long PlaceOfferForProperty(string userId, Offer offer);
        bool PropertyCanBeEditedByUser(long propertyId, string userId);
    }
}