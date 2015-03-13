using System.ComponentModel.DataAnnotations;

namespace DeedSimple.Models
{
    public enum PropertyTypeModel
    {
        [Display(Name = "Detached")]
        Detached,
        [Display(Name = "Semi-detached")]
        SemiDetached,
        [Display(Name = "Mid-terrace")]
        MidTerrace,
        [Display(Name = "End-terrace")]
        EndTerrace,
        [Display(Name = "Flat")]
        Flat
    }
}