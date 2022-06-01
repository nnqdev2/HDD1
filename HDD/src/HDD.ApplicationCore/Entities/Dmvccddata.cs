using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class Dmvccddata
    {
        public Dmvccddata()
        {
            OwnersVins = new HashSet<OwnersVin>();
            SecondaryOwnerAssignments = new HashSet<SecondaryOwnerAssignment>();
        }

        public string Vin { get; set; } = null!;
        public string? Plate { get; set; }
        public int? ModelYear { get; set; }
        public int? Gvw { get; set; }
        public int? RegistrationWeight { get; set; }
        public string? WeightRange { get; set; }
        public string? OwnerName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? County { get; set; }
        public string? PubliclyOwned { get; set; }
        public string? RegistrationExpiration { get; set; }
        public string? RenewalAgency { get; set; }
        public string? ChangedOwnership { get; set; }
        public DateTime? RunDate { get; set; }
        public DateTime? EntryDateTime { get; set; }

        public virtual RetrofitApplication RetrofitApplication { get; set; } = null!;
        public virtual RetrofitCertification RetrofitCertification { get; set; } = null!;
        public virtual ICollection<OwnersVin> OwnersVins { get; set; }
        public virtual ICollection<SecondaryOwnerAssignment> SecondaryOwnerAssignments { get; set; }
    }
}
