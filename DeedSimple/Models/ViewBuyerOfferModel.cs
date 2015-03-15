using System.ComponentModel.DataAnnotations;
using DeedSimple.Domain;

namespace DeedSimple.Models
{
    public class ViewBuyerOfferModel
    {
        public long OfferId { get; set; }
        public long PropertyId { get; set; }

        [DataType(DataType.Currency)]
        public decimal OfferPrice { get; set; }

        public OfferState State { get; set; }

        [DataType(DataType.Text)]
        public string TagLine { get; set; }

        public Image MainImage { get; set; }
    }
}