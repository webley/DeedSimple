using System.Collections.Generic;

namespace DeedSimple.Domain
{
    public class Property
    {
        public long Id { get; set; }
        public PropertyType Type { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public string AskingPriceDescription { get; set; }

        public string Road { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public virtual List<Image> Images { get; set; }
        public virtual List<Offer> OutstandingOffers { get; set; }
    }
}
