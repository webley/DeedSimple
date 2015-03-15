﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DeedSimple.ViewModel.Enum;
using DeedSimple.ViewModel.Image;

namespace DeedSimple.ViewModel.Property
{
    public class EditPropertyModel
    {
        public EditPropertyModel(long propertyId)
        {
            PropertyId = propertyId;
        }

        public long PropertyId { get; private set; }

        [Required]
        [Display(Name = "Property type")]
        public PropertyType Type { get; set; }

        [Required]
        [Display(Name = "Property tag line", Description = "The title that will appear on your property page")]
        public string TagLine { get; set; }

        [Required]
        [Display(Name = "Road")]
        public string Road { get; set; }

        [Required]
        [Display(Name = "Town")]
        public string Town { get; set; }

        [Required]
        [Display(Name = "County")]
        public string County { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostCode { get; set; }

        [Required]
        [Display(Name = "Enter a description")]
        public string Description { get; set; }

        //[Required]
        //[Display(Name = "Upload some images")]
        //public List<AddPropertyImageModel> Images { get; set; }

        [Required]
        [Display(Name = "Asking price")]
        public decimal AskingPrice { get; set; }
    }
}