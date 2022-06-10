using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class OwnersVin
    {
        public int OwnersVinId { get; set; }
        public string OwnerId { get; set; } = null!;
        public string Vin { get; set; } = null!;
        public string? PrimaryOwner { get; set; }
        public bool OwnerStatus { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        //public virtual AspNetUser Owner { get; set; } = null!;
        public virtual Dmvccddata VinNavigation { get; set; } = null!;
    }
}
