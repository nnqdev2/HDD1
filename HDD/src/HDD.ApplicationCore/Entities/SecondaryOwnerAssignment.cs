using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HDD.ApplicationCore.Entities
{
    public partial class SecondaryOwnerAssignment
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SecondaryOwnerAssignmentId { get; set; }
        public string OwnerId { get; set; } = null!;
        public string Vin { get; set; } = null!;
        public string IncomingSecondaryOwnerEmail { get; set; } = null!;
        public DateTime? AssignedDate { get; set; }
        public bool? AssignmentCompleted { get; set; }

        //public virtual AspNetUser Owner { get; set; } = null!;
        public virtual Dmvccddata VinNavigation { get; set; } = null!;
    }
}
