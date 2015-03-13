using System.ComponentModel.DataAnnotations;

namespace DeedSimple.Models.Seller
{
    public class AddPropertyModel
    {
        [Required]
        [Display(Name = "Property type")]
        public PropertyTypeModel Type { get; set; }

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
        //public List<Image> Images { get; set; }

        //[DataType(DataType.Upload)]
        //public HttpPostedFileBase Image { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Asking price")]
        public decimal AskingPrice { get; set; }
    }
}