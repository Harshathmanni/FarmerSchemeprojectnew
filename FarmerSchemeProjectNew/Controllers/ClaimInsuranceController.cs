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
    public class ClaimInsuranceController : ControllerBase
    {
        private readonly DbfarmerContext db;

        public ClaimInsuranceController(DbfarmerContext context)
        {
            db = context;
        }

        [HttpGet]

        public IActionResult getClaimdata()
        {
            List<Claim_CInsurance> li = new List<Claim_CInsurance>();

            var claiminsurancelist = (from c in db.ClaimInsurances
                                      join i in db.Insurances
                                      on c.PolicyNo equals i.PolicyNo
                                      select new { c.PolicyNo, c.NameofInsure, c.DateOfLoss, c.CauseofLoss, i.InsuranceCompany, i.SumInsured }).ToList();

            foreach (var item in claiminsurancelist)
            {
                Claim_CInsurance PI = new Claim_CInsurance();
                PI.PolicyNo = item.PolicyNo;
                PI.NameofInsure = item.NameofInsure;
                PI.DateOfLoss = (DateTime)item.DateOfLoss;
                PI.CauseofLoss = item.CauseofLoss;
                PI.InsuranceCompany = item.InsuranceCompany;
                PI.SumInsured = item.SumInsured;



                li.Add(PI);

            }
            return Ok(li);
        }

        private IActionResult View(List<ClaimInsurance> li)
        {
            throw new NotImplementedException();
        }




        #region 
        [HttpPost]

        /* public IActionResult AddInsurance([FromBody] ClaimInsurance claiminsurance)
         {
             try
             {
                 if (claiminsurance == null)
                 {
                     return BadRequest("data not entered");
                 }

                 else
                 {
                     db.ClaimInsurances.Add(claiminsurance);
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


        public IActionResult AddInsurance(Claim_CInsurance claim_CInsurance)
        {
            Insurance insurance = new Insurance();
            insurance.SumInsured = claim_CInsurance.SumInsured;
            insurance.InsuranceCompany = claim_CInsurance.InsuranceCompany;
            insurance.UserId = (int)claim_CInsurance.UserId;
            db.Insurances.Add(insurance);




            ClaimInsurance claimInsurance = new ClaimInsurance();
            claimInsurance.PolicyNo = claim_CInsurance.PolicyNo;
            claimInsurance.NameofInsure = claim_CInsurance.NameofInsure;
            claimInsurance.DateOfLoss = claim_CInsurance.DateOfLoss;
            claimInsurance.CauseofLoss = claim_CInsurance.CauseofLoss;
            db.ClaimInsurances.Add(claimInsurance);
            db.SaveChanges();

            return Ok("Success");

        }

    }
    #endregion
}




   
