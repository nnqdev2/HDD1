using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDD.ApplicationCore.Entities;
public class ApIsVinClaimable
{
    public bool IsVinClaimable { get; set; }
    public int ReturnCode { get; set; }
    public string? ReturnMessage { get; set; }

}
