using System.ComponentModel.DataAnnotations;

namespace DeedSimple.Models
{
    public class ConfirmAcceptOfferModel
    {
        public long OfferId { get; set; }

        [DataType(DataType.Currency)]
        public decimal OfferPrice { get; set; }
    }
}