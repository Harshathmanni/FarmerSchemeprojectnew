using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class Insurance
    {
        public string InsuranceCompany { get; set; }
        public int? SumInsuredperhectar { get; set; }
        public int? SharePremium { get; set; }
        public int? PremiumAmmount { get; set; }
        public string CropName { get; set; }
        public string Area { get; set; }
        public int? SumInsured { get; set; }
        public int UserId { get; set; }
        public string Season { get; set; }
        public string Year { get; set; }
        public int? PolicyNo { get; set; }
        public int InsuranceId { get; set; }

        public virtual ClaimInsurance PolicyNoNavigation { get; set; }
        public virtual Roletable User { get; set; }
    }
}
