using System.Collections.Generic;
using DeedSimple.Domain;

namespace DeedSimple.Processor
{
    public interface IPropertyProcessor
    {
        Property GetProperty(long propertyId);
        List<Property> GetPropertiesForUser(string userId);
        long AddPropertyForUser(string userId, Property property);
        bool PropertyCanBeEditedByUser(long propertyId, string userId);
    }
}