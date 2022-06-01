using System.ComponentModel.DataAnnotations;

namespace HDD.Web.ViewModels
{
    public class AssignSecondaryOwnerViewModel
    {
        //[RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
        //ErrorMessage = "Must be a valid email")]
        //[Required]
        public string? SecondaryOwnerId { get; set; }

        public virtual ICollection<VinSecondaryOwnerAction>? VinSecondaryOwnerActions { get; set; }
    }
}
