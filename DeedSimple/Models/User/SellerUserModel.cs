using System.Collections.Generic;
using DeedSimple.Domain;

namespace DeedSimple.Models.User
{
    public class SellerUserModel
    {
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
    }
}