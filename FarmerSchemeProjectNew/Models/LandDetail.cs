using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class LandDetail
    {
        public LandDetail()
        {
            CropTables = new HashSet<CropTable>();
            SellCrops = new HashSet<SellCrop>();
        }

        public string Area { get; set; }
        public string Address { get; set; }
        public int? PinCode { get; set; }
        public int FarmerId { get; set; }
        public string EmailId { get; set; }

        public virtual Registration Email { get; set; }
        public virtual ICollection<CropTable> CropTables { get; set; }
        public virtual ICollection<SellCrop> SellCrops { get; set; }
    }
}
