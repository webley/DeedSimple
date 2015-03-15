using System.Collections.Generic;
using System.Linq;
using DeedSimple.BLL.Converters;
using DeedSimple.BLL.Interface;
using DeedSimple.DataAccess;
using DeedSimple.ViewModel.Offer;
using DeedSimple.ViewModel.Property;
using DeedSimple.ViewModel.Enum;
using DomainPropertySortOrder = DeedSimple.Domain.PropertySortOrder;

namespace DeedSimple.BLL.Implementation
{
    public class PropertyProcessor : IPropertyProcessor
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyProcessor(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public ViewPropertyDetailsModel GetProperty(long propertyId)
        {
            return _propertyRepository.GetProperty(propertyId).ToViewPropertyDetailsModel();
        }

        public List<ViewPropertyDetailsModel> GetPropertiesForUser(string userId)
        {
            return _propertyRepository
                .GetPropertiesBySellerId(userId)
                .Select(p => p.ToViewPropertyDetailsModel())
                .ToList();
        }

        public List<ViewOfferModel> GetOffersForBuyer(string buyerUserId)
        {
            return _propertyRepository
                .GetOffersByBuyerId(buyerUserId)
                .Select(offer =>
                {
                    var prop = _propertyRepository.GetProperty(offer.PropertyId);
                    return offer.ToViewOfferModel(prop.Images.FirstOrDefault(), prop.TagLine);
                })
                .ToList();
        }

        public ViewOfferModel GetOffer(long offerId)
        {
            var offer = _propertyRepository.GetOffer(offerId);
            var property = _propertyRepository.GetProperty(offer.PropertyId);
            return _propertyRepository.GetOffer(offerId).ToViewOfferModel(property.Images.FirstOrDefault(), property.TagLine);
        }

        public List<ViewOfferModel> GetOffersForSeller(string sellerUserId)
        {
            return _propertyRepository
                .GetPropertiesBySellerId(sellerUserId)
                .SelectMany(prop => prop.OutstandingOffers)
                .Select(offer =>
                {
                    var prop = _propertyRepository.GetProperty(offer.PropertyId);
                    return offer.ToViewOfferModel(prop.Images.FirstOrDefault(), prop.TagLine);
                })
                .ToList();
        }

        public IEnumerable<ViewPropertyOverviewModel> GetPropertiesFiltered(PropertySortOrder sortOrder, string searchString)
        {
            return _propertyRepository.GetPropertiesFiltered((DomainPropertySortOrder)sortOrder, searchString)
                .Select(prop => prop.ToViewPropertyOverviewModel());
        }

        public long AddPropertyForUser(string userId, AddPropertyModel property)
        {
            return _propertyRepository.AddPropertyForUser(userId, property.ToProperty());
        }

        public long PlaceOfferForProperty(AddOfferModel offer)
        {
            return _propertyRepository.PlaceOfferForProperty(offer.ToOffer());
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