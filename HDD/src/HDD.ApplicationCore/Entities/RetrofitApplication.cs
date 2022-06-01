using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class RetrofitApplication
    {
        public RetrofitApplication()
        {
            VehicleDocuments = new HashSet<VehicleDocument>();
        }

        public string Vin { get; set; } = null!;
        public int? EngineYear { get; set; }
        public string? EngineManufacturer { get; set; }
        public string? EngineFamilyNumber { get; set; }
        public string? EngineDisplacement { get; set; }
        public string? ArtFamilyName { get; set; }
        public string? ApplicationDate { get; set; }
        public string? RetrofitType { get; set; }
        public string? RetrofitProvider { get; set; }
        public DateTime? RunDate { get; set; }
        public DateTime? EntryDateTime { get; set; }
        public string? Comments { get; set; }
        public string LastUpdatedBy { get; set; } = null!;
        public DateTime LastUpdatedDate { get; set; }

        //public virtual AspNetUser LastUpdatedByNavigation { get; set; } = null!;
        public virtual ValidRetrofitProvider? RetrofitProviderNavigation { get; set; }
        public virtual ValidRetrofitType? RetrofitTypeNavigation { get; set; }
        public virtual Dmvccddata VinNavigation { get; set; } = null!;
        public virtual ICollection<VehicleDocument> VehicleDocuments { get; set; }
    }
}
