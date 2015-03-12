using System.Collections.Generic;

namespace DeedSimple.Domain
{
    public class BuyerUser
    {
        public string Id { get; set; }

        public virtual List<Offer> Offers { get; set; }
    }
}
