using System.Collections.Generic;
using DeedSimple.DataAccess;
using DeedSimple.Domain;

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

        public long AddPropertyForUser(string userId, Property property)
        {
            return _propertyRepository.AddPropertyForUser(userId, property);
        }

        public bool PropertyCanBeEditedByUser(long propertyId, string userId)
        {
            return _propertyRepository.PropertyCanBeEditedByUser(propertyId, userId);
        }
    }
}