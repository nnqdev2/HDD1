using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class ValidCertifiedType
    {
        public ValidCertifiedType()
        {
            RetrofitCertifications = new HashSet<RetrofitCertification>();
        }

        public string CertifiedType { get; set; } = null!;
        public string? Description { get; set; }
        public short? Sequence { get; set; }

        public virtual ICollection<RetrofitCertification> RetrofitCertifications { get; set; }
    }
}
