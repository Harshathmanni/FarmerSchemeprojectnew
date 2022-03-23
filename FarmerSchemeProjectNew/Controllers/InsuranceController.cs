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
    public class InsuranceController : ControllerBase
    { 
            private readonly DbfarmerContext db;

            public InsuranceController(DbfarmerContext context)
            {
                db = context;
            }

        [HttpGet]

        public IActionResult Get()
        {

            var insurance = db.Insurances.ToList();

            if (insurance != null)
            {
                return Ok(insurance);
            }
            else
            {
                return NotFound("data not found");
            }

        }

        #region 
        [HttpPost]

        public IActionResult AddInsurance([FromBody] Insurance insurance)
        {
            try
            {
                if (insurance == null)
                {
                    return BadRequest("data not entered");
                }

                else
                {
                    db.Insurances.Add(insurance);
                    db.SaveChanges();
                    return Ok("Record Added!!");
                }
            }

            catch (Exception e)
            {
                return Ok("Some Error Occured!!!");
            }

        }
        #endregion
    }
}