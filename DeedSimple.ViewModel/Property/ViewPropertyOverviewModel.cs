using System.ComponentModel.DataAnnotations;
using DeedSimple.ViewModel.Image;

namespace DeedSimple.ViewModel.Property
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
        public ViewImageModel MainImage { get; set; }
    }
}