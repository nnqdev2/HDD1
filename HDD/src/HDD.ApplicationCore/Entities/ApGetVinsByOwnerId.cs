using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDD.ApplicationCore.Entities;
public class ApGetVinsByOwnerId
{
    public int OwnersVinId { get; set; }
    public string OwnerId { get; set; } = null!;
    public string Vin { get; set; } = null!;
    public string Plate { get; set; } = null!;
    public string? PrimaryOwner { get; set; }
    public DateTime? UpdateDateTime { get; set; }
    public string CertifiedType { get; set; } = null!;
    public string? Description { get; set; }
}
