using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class ValidCertificationYear
    {
        public ValidCertificationYear()
        {
            VehicleDocuments = new HashSet<VehicleDocument>();
        }

        public short CertificationYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<VehicleDocument> VehicleDocuments { get; set; }
    }
}
