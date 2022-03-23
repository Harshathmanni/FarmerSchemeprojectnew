using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FarmerSchemeProjectNew.Models
{
    public class Bidder_Welcome
    {
        [Key]
        public int SellId { get; set; }
        [DataMember]
        public string CropName { get; set; }
        [DataMember]
        public string CropType { get; set; }
        [DataMember]
        public int BasePrice { get; set; } //bidding
        [DataMember]
        public int CurrentBid { get; set; }
        [DataMember]
        public int BidAmmount { get; set; }
       


    }






}
