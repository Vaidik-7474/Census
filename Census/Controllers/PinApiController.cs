using Census.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Census.Controllers
{
    public class PinApiController : ApiController
    {
        CensusDBEntities db1 = new CensusDBEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetFamiliesByPincode(int pin)
        {
            List<Family> obj = db1.Families.Where(model => model.pincode == pin).ToList();
            return Ok(obj);
        }
    }
}
