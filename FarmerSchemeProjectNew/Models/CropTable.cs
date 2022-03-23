using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class CropTable
    {
        public string CropType { get; set; }
        public string CropName { get; set; }
        public int CropId { get; set; }
        public int FarmerId { get; set; }

        public virtual LandDetail Farmer { get; set; }
    }
}
