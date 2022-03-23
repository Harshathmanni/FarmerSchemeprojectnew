using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class Roletable
    {
        public Roletable()
        {
            Insurances = new HashSet<Insurance>();
        }

        public int UserId { get; set; }
        public string RoleType { get; set; }
        public string ApprovedStatus { get; set; }
        public string EmailId { get; set; }

        public virtual Registration Email { get; set; }
        public virtual ICollection<Insurance> Insurances { get; set; }
    }
}
