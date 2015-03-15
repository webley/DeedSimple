using System.Collections.Generic;
using DeedSimple.ViewModel.Enum;
using DeedSimple.ViewModel.Property;
using DeedSimple.ViewModel.Offer;

namespace DeedSimple.BLL.Interface
{
    public interface IPropertyProcessor
    {
        ViewPropertyDetailsModel GetProperty(long propertyId);
        IEnumerable<ViewPropertyOverviewModel> GetPropertiesFiltered(PropertySortOrder sortOrder, string searchString);
        List<ViewPropertyDetailsModel> GetPropertiesForUser(string userId);
        List<ViewOfferModel> GetOffersForBuyer(string buyerUserId);
        ViewOfferModel GetOffer(long offerId);
        List<ViewOfferModel> GetOffersForSeller(string sellerUserId);
        long AddPropertyForUser(AddPropertyModel property);
        long PlaceOfferForProperty(AddOfferModel offer);
        bool PropertyCanBeEditedByUser(long propertyId, string userId);

        void CancelOffer(long offerId);
        void AcceptOffer(long offerId);
        void RejectOffer(long offerId);
    }
}