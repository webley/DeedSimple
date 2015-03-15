using System.Collections.Generic;
using DeedSimple.ViewModel.Property;

namespace DeedSimple.ViewModel.User
{
    public class ViewSellerUserModel
    {
        public string Id { get; set; }

        public virtual List<ViewPropertyDetailsModel> Properties { get; set; }
    }
}
