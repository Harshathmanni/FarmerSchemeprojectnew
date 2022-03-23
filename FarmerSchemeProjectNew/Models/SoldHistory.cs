using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class SoldHistory
    {
        public DateTime Date { get; set; }
        public string CropName { get; set; }
        public int? Quantity { get; set; }
        public string Msp { get; set; }
        public int? SoldPrice { get; set; }
        public int? TotalPrice { get; set; }
        public int SellId { get; set; }

        public virtual SellCrop Sell { get; set; }
    }
}
