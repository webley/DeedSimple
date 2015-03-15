using System.Collections.Generic;
using DeedSimple.ViewModel.Offer;

namespace DeedSimple.ViewModel.User
{
    public class ViewBuyerUserModel
    {
        public string Id { get; set; }
        public virtual List<ViewOfferModel> Offers { get; set; }
    }
}
