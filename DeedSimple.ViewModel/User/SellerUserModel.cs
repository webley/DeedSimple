using System.Collections.Generic;
using DeedSimple.ViewModel.Property;

namespace DeedSimple.ViewModel.User
{
    public class SellerUserModel
    {
        public string Name { get; set; }
        public List<ViewPropertyDetailsModel> Properties { get; set; }
    }
}