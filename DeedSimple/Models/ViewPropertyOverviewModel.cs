using System.ComponentModel.DataAnnotations;
using DeedSimple.Domain;

namespace DeedSimple.Models
{
    public class ViewPropertyOverviewModel
    {
        public ViewPropertyOverviewModel(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }

        [DataType(DataType.Text)]
        [Display(Name = "Tag Line")]
        public string TagLine { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Asking Price")]
        public decimal AskingPrice { get; set; }

        [Display(Name = "Image")]
        public Image MainImage { get; set; }
    }
}