using System.ComponentModel.DataAnnotations;
using DeedSimple.ViewModel.Enum;
using DeedSimple.ViewModel.Image;

namespace DeedSimple.ViewModel.Offer
{
    public class ViewOfferModel
    {
        public long OfferId { get; set; }
        public long PropertyId { get; set; }

        [DataType(DataType.Currency)]
        public decimal OfferPrice { get; set; }

        public OfferState State { get; set; }

        [DataType(DataType.Text)]
        public string TagLine { get; set; }

        public ViewImageModel MainImage { get; set; }
    }
}