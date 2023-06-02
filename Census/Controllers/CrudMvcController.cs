using Census.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Census.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Family> familyList = new List<Family>();
            client.BaseAddress = new Uri("https://localhost:44359/api/CrudApi");

            var response = client.GetAsync("CrudApi");
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<List<Family>>();
                display.Wait();
                familyList = display.Result;
            }


            return View(familyList);
        }

        public ActionResult Details(int id)
        {
            Family f = null;
            client.BaseAddress = new Uri("https://localhost:44359/api/CrudApi");

            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<Family>();
                display.Wait();
                f = display.Result;
            }
            return View(f);
        }

        
        public ActionResult DetailsByPincode(int pin)
        {
            List<Family> familyList = new List<Family>();
            client.BaseAddress = new Uri("https://localhost:44359/api/PinApi");

            var response = client.GetAsync("PinApi?pin=" + pin.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<List<Family>>();
                display.Wait();
                familyList = display.Result;
            }

            return View(familyList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Family fam)
        {
            client.BaseAddress = new Uri("https://localhost:44359/api/CrudApi");

            var response = client.PostAsJsonAsync<Family>("CrudApi", fam);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        public ActionResult Edit(int id)
        {
            Family f = null;
            client.BaseAddress = new Uri("https://localhost:44359/api/CrudApi");

            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<Family>();
                display.Wait();
                f = display.Result;
            }
            return View(f);
        }

        [HttpPost]
        public ActionResult Edit(Family f)
        {
            client.BaseAddress = new Uri("https://localhost:44359/api/CrudApi");

            var response = client.PutAsJsonAsync<Family>("CrudApi", f);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                return RedirectToAction("Index");
            }

            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            Family f = null;
            client.BaseAddress = new Uri("https://localhost:44359/api/CrudApi");

            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                var display = test.Content.ReadAsAsync<Family>();
                display.Wait();
                f = display.Result;
            }
            return View(f);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44359/api/CrudApi");

            var response = client.DeleteAsync("CrudApi/" + id.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode) // successStatusCode = 200
            {
                return RedirectToAction("Index");
            }

            return View("Delete");
        }
    }
}