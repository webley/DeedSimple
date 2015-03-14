using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeedSimple.Domain
{
    public class BuyerUser
    {
        public string Id { get; set; }

        public virtual List<Offer> Offers { get; set; }
    }
}
