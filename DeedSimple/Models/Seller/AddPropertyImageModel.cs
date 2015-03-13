using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DeedSimple.Models.Seller
{
    public class AddPropertyImageModel
    {
        public long PropertyId { get; set; }

        [DataType(DataType.Upload)]
        [Required]
        [Display(Name = "Upload an image")]
        public HttpPostedFileBase Image { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [Display(Name = "Image caption")]
        public string Caption { get; set; }
    }
}