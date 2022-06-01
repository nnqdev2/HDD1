using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class RetrofitCertification
    {
        public string Vin { get; set; } = null!;
        public string? Vinstatus { get; set; }
        public string? AgencyChanged { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? Certified { get; set; }
        public string? ActionInspectorId { get; set; }
        public DateTime? EntryDateTime { get; set; }
        public string? EntryUserId { get; set; }
        public string? Comments { get; set; }

        public virtual ValidCertifiedType? CertifiedNavigation { get; set; }
        public virtual Dmvccddata VinNavigation { get; set; } = null!;
        public virtual ValidStatusType? VinstatusNavigation { get; set; }
    }
}
