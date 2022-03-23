using FarmerSchemeProjectNew.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmerSchemeProjectNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiddingController : ControllerBase
    {
        private readonly DbfarmerContext db;

        public BiddingController(DbfarmerContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult getBidderdata()
        {
            List<Bidder_Welcome> li = new List<Bidder_Welcome>();

            var biddinglist = (from b in db.Biddings
                               join s in db.SellCrops
                               on b.SellId equals s.SellId
                               select new { s.SellId, s.CropType, s.CropName, b.BasePrice, b.CurrentBid, b.BidAmmount }).ToList();

            foreach (var item in biddinglist)
            {
                Bidder_Welcome BD = new Bidder_Welcome();
                BD.SellId = item.SellId;
                BD.CropType = item.CropType;
                BD.CropName = item.CropName;
                BD.BasePrice = (int)item.BasePrice;
                BD.CurrentBid = (int)item.CurrentBid;
                BD.BidAmmount = (int)item.BidAmmount;


                li.Add(BD);


            }
            return Ok(li);
        }

        private IActionResult View(List<Bidding> li)
        {
            throw new NotImplementedException();
        }




        #region 
        [HttpPost]

        /* public IActionResult AddBidding([FromBody] Bidding bidding)
          {
              try
              {
                  if (bidding == null)
                  {
                      return BadRequest("data not entered");
                  }

                  else
                  {
                      db.Biddings.Add(bidding);
                      db.SaveChanges();
                      return Ok("Record Added!!");
                  }
              }

              catch (Exception e)
              {
                  return Ok("Some Error Occured!!!");
              }

          }
          #endregion*/
        public IActionResult AddSellCrop(Bidder_Welcome bidder_Welcome)
        {
            SellCrop sellcrop = new SellCrop();
            sellcrop.CropName = bidder_Welcome.CropName;
            sellcrop.CropType = bidder_Welcome.CropType;
          

            db.SellCrops.Add(sellcrop);



            Bidding bidding = new Bidding();
            bidding.BasePrice = bidder_Welcome.BasePrice;
            bidding.CurrentBid = bidder_Welcome.CurrentBid;
            bidding.BidAmmount = bidder_Welcome.BidAmmount;
          

            db.Biddings.Add(bidding);
            db.SaveChanges();

            return Ok("Success");

        }

    }
    #endregion
}

   

   
