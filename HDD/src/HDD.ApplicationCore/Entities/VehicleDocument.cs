using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class VehicleDocument
    {
        public int VehicleDocumentId { get; set; }
        public string Vin { get; set; } = null!;
        public string DocumentName { get; set; } = null!;
        public int DocumentTypeId { get; set; }
        public short CertificationYear { get; set; }
        public string UploadedBy { get; set; } = null!;
        public DateTime UploadedDate { get; set; }
        public bool? InspectorValidated { get; set; }
        public string? DeleteRequestedBy { get; set; }
        public DateTime? DeleteRequestedDate { get; set; }

        public virtual ValidCertificationYear CertificationYearNavigation { get; set; } = null!;
        //public virtual AspNetUser? DeleteRequestedByNavigation { get; set; }
        public virtual ValidDocumentType DocumentType { get; set; } = null!;
        //public virtual AspNetUser UploadedByNavigation { get; set; } = null!;
        public virtual RetrofitApplication VinNavigation { get; set; } = null!;
    }
}
