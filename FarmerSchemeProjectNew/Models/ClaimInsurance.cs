using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class ClaimInsurance
    {
        public ClaimInsurance()
        {
            Insurances = new HashSet<Insurance>();
        }

        public int PolicyNo { get; set; }
        public string NameofInsure { get; set; }
        public DateTime? DateOfLoss { get; set; }
        public string CauseofLoss { get; set; }

        public virtual ICollection<Insurance> Insurances { get; set; }
    }
}
