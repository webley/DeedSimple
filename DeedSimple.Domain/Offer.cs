using System.ComponentModel.DataAnnotations.Schema;

namespace DeedSimple.Domain
{
    public class Offer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long PropertyId { get; set; }
        public decimal Price { get; set; }
        public OfferState State { get; set; }
    }
}
