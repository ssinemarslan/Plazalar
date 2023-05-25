using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcapikatman.Models;
using System.Net.Http;

namespace mvcapikatman.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Index()
        {
            IEnumerable<mvcpersonelmodel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("PersonellerBilgis").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcpersonelmodel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcpersonelmodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("PersonellerBilgis/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcpersonelmodel>().Result);
            }


        }
        [HttpPost]
        public ActionResult EY(mvcpersonelmodel personel)
        {
            if (personel.PersonelNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("PersonellerBilgis", personel).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("PersonellerBilgis/" + personel.PersonelNo, personel).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("PeronellerBilgis/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

    }
}