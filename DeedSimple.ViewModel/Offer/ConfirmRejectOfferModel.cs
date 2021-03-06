﻿using System.ComponentModel.DataAnnotations;

namespace DeedSimple.ViewModel.Offer
{
    public class ConfirmRejectOfferModel
    {
        public long OfferId { get; set; }

        [DataType(DataType.Currency)]
        public decimal OfferPrice { get; set; }
    }
}