using HDD.Web.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HDD.Web.ViewModels
{
    //[AtLeastOneProperty("Vin", "Plate", ErrorMessage="VIN and/or Plate is required")]
    public class IndexViewModel
    {
        [VinOrPlateRequired("Plate", ErrorMessage = "Please enter a license plate or vehicle identification number (VIN).")]
        [Display(Name = "VIN")]
        public string? Vin { get; set; }

        [VinOrPlateRequired("Vin", ErrorMessage = "Please enter a license plate or vehicle identification number (VIN).")]
        public string? Plate { get; set; }

        
        //[RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
        //ErrorMessage = "Must be a valid email")]
        //[Required]
        //public string? Email { get; set; }

    }
}
