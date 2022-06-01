using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class ValidStatusType
    {
        public ValidStatusType()
        {
            RetrofitCertifications = new HashSet<RetrofitCertification>();
        }

        public string StatusType { get; set; } = null!;
        public string? Description { get; set; }
        public short? Sequence { get; set; }

        public virtual ICollection<RetrofitCertification> RetrofitCertifications { get; set; }
    }
}
