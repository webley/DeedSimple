using System.Collections.Generic;
using DeedSimple.DataAccess;
using DeedSimple.Domain;
using PagedList;

namespace DeedSimple.Processor
{
    public class PropertyProcessor : IPropertyProcessor
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyProcessor(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public Property GetProperty(long propertyId)
        {
            return _propertyRepository.GetProperty(propertyId);
        }

        public List<Property> GetPropertiesForUser(string userId)
        {
            return _propertyRepository.GetPropertiesBySellerId(userId);
        }

        public IEnumerable<Property> GetPropertiesFiltered(PropertySortOrder sortOrder, string searchString)
        {
            return _propertyRepository.GetPropertiesFiltered(sortOrder, searchString);
        }

        public long AddPropertyForUser(string userId, Property property)
        {
            return _propertyRepository.AddPropertyForUser(userId, property);
        }

        public long PlaceOfferForProperty(string userId, Offer offer)
        {
            return _propertyRepository.PlaceOfferForProperty(userId, offer);
        }

        public bool PropertyCanBeEditedByUser(long propertyId, string userId)
        {
            return _propertyRepository.PropertyCanBeEditedByUser(propertyId, userId);
        }
    }
}