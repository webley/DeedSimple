using System.Collections.Generic;
using System.Linq;
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

        public List<Offer> GetOffersForBuyer(string buyerUserId)
        {
            return _propertyRepository.GetOffersByBuyerId(buyerUserId);
        }

        public Offer GetOffer(long offerId)
        {
            return _propertyRepository.GetOffer(offerId);
        }

        public List<Offer> GetOffersForSeller(string sellerUserId)
        {
            var properties = _propertyRepository.GetPropertiesBySellerId(sellerUserId);
            return properties.SelectMany(prop => prop.OutstandingOffers).ToList();
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

        public void CancelOffer(long offerId)
        {
            _propertyRepository.CancelOffer(offerId);
        }

        public void AcceptOffer(long offerId)
        {
            _propertyRepository.AcceptOffer(offerId);
        }

        public void RejectOffer(long offerId)
        {
            _propertyRepository.RejectOffer(offerId);
        }
    }
}