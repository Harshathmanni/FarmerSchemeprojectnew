using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class BankDetail
    {
        public string AccountNo { get; set; }
        public string Ifsccode { get; set; }
        public string BankName { get; set; }
        public string EmailId { get; set; }

        public virtual Registration Email { get; set; }
    }
}
