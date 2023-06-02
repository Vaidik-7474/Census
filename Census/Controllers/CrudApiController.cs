using Census.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Census.Controllers
{
    public class CrudApiController : ApiController
    {
        CensusDBEntities db = new CensusDBEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetFamilies()
        {
            List<Family> obj = db.Families.ToList();
            return Ok(obj);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetFamiliesById(int id)
        {
            var fam = db.Families.Where(model => model.houseNo == id).FirstOrDefault();
            return Ok(fam);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetFamiliesByPincode(int pin)
        {
            List<Family> obj = db.Families.Where(model => model.pincode == pin).ToList();
            return Ok(obj);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertFamilies(Family fam)
        {
            db.Families.Add(fam);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateFamilies(Family f)
        {
         

            var fam = db.Families.Where(model => model.houseNo == f.houseNo).FirstOrDefault();
            if (fam != null)
            {
                fam.houseNo = f.houseNo;
                fam.totalPerson = f.totalPerson;
                fam.totalMale = f.totalMale;
                fam.totalFemale = f.totalFemale;
                fam.totalChild = f.totalChild;
                fam.street = f.street;
                fam.village = f.village;
                fam.taluka = f.taluka;
                fam.district = f.district;
                fam.state = f.state;
                fam.pincode = f.pincode;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteFamilies(int id)
        {
            var fam = db.Families.Where(model => model.houseNo == id).FirstOrDefault();
            db.Entry(fam).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
