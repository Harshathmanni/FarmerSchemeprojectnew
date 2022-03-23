using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class SellCrop
    {
        public SellCrop()
        {
            Biddings = new HashSet<Bidding>();
            SoldHistories = new HashSet<SoldHistory>();
        }

        public string CropName { get; set; }
        public string CropType { get; set; }
        public string FertilizerType { get; set; }
        public int? Quantity { get; set; }
        public string SoilPhcertificate { get; set; }
        public int FarmerId { get; set; }
        public string Status { get; set; }
        public int SellId { get; set; }

        public virtual LandDetail Farmer { get; set; }
        public virtual ICollection<Bidding> Biddings { get; set; }
        public virtual ICollection<SoldHistory> SoldHistories { get; set; }
    }
}
