﻿using System.Collections.Generic;

namespace DeedSimple.Domain
{
    public class SellerUser
    {
        public string Id { get; set; }

        public virtual List<Property> Properties { get; set; }
    }
}