using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DeedSimple.Domain;

namespace DeedSimple.Models
{
    public class ViewPropertyDetailsModel
    {
        public ViewPropertyDetailsModel()
        {
            
        }

        public ViewPropertyDetailsModel(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }

        [DataType(DataType.Text)]
        [Display(Name = "Property Type")]
        public PropertyType Type { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Tag Line")]
        public string TagLine { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Asking Price")]
        public decimal AskingPrice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Offer Price")]
        public decimal OfferPrice { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Road")]
        public string Road { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Town")]
        public string Town { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "County")]
        public string County { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        public List<Image> Images { get; set; }
    }
}