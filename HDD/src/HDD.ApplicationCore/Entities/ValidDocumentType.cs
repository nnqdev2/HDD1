using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class ValidDocumentType
    {
        public ValidDocumentType()
        {
            VehicleDocuments = new HashSet<VehicleDocument>();
        }

        public int DocumentTypeId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public short? Sequence { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? DocumentTypeGroup { get; set; }

        public virtual ICollection<VehicleDocument> VehicleDocuments { get; set; }
    }
}
