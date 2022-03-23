using System;
using System.Collections.Generic;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class Bidding
    {
        public int? BasePrice { get; set; }
        public int? CurrentBid { get; set; }
        public int? BidAmmount { get; set; }
        public int BidderId { get; set; }
        public DateTime? BiddingDate { get; set; }
        public int SellId { get; set; }

        public virtual SellCrop Sell { get; set; }
    }
}
