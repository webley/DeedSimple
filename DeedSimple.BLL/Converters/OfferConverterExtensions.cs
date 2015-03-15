using DeedSimple.Domain;
using DeedSimple.ViewModel.Offer;
using ModelOfferState = DeedSimple.ViewModel.Enum.OfferState;

namespace DeedSimple.BLL.Converters
{
    public static class OfferConverterExtensions
    {
        public static Offer ToOffer(this AddOfferModel model)
        {
            var offer = new Offer
            {
                PropertyId = model.PropertyId,
                Price = model.OfferPrice
            };

            return offer;
        }

        public static ViewOfferModel ToViewOfferModel(this Offer offerEntity, Image mainImage, string tagLine)
        {
            var model = new ViewOfferModel
            {
                OfferId = offerEntity.Id,
                PropertyId = offerEntity.PropertyId,
                OfferPrice = offerEntity.Price,
                State = (ModelOfferState)offerEntity.State,
                TagLine = tagLine,
                MainImage = mainImage.ToViewImageModel()
            };

            return model;
        }
    }
}
