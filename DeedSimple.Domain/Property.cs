using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeedSimple.Domain
{
    public class Property
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string SellerId { get; set; }

        public PropertyType Type { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public decimal AskingPrice { get; set; }

        public string Road { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public virtual List<Image> Images { get; set; }
        public virtual List<Offer> OutstandingOffers { get; set; }
    }
}
