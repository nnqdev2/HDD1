using System;
using System.Collections.Generic;

namespace HDD.ApplicationCore.Entities
{
    public partial class ValidRetrofitProvider
    {
        public ValidRetrofitProvider()
        {
            RetrofitApplications = new HashSet<RetrofitApplication>();
        }

        public string RetrofitProvoder { get; set; } = null!;
        public string? Description { get; set; }
        public short? Sequence { get; set; }

        public virtual ICollection<RetrofitApplication> RetrofitApplications { get; set; }
    }
}
