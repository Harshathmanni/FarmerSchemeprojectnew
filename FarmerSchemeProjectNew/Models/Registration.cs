using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class Registration
    {
        public Registration()
        {
            BankDetails = new HashSet<BankDetail>();
            LandDetails = new HashSet<LandDetail>();
            Roletables = new HashSet<Roletable>();
        }

        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConformPassword { get; set; }
        public string FullName { get; set; }
        public string ContactNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? PinCode { get; set; }
        public string Aadhaar { get; set; }
        public string Pan { get; set; }
        public int? TraderLicence { get; set; }
        public string Certificate { get; set; }

        public virtual ICollection<BankDetail> BankDetails { get; set; }
        public virtual ICollection<LandDetail> LandDetails { get; set; }
        public virtual ICollection<Roletable> Roletables { get; set; }
    }
}
