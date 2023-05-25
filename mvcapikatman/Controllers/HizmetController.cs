using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcapikatman.Models;
using System.Net.Http;

namespace mvcapikatman.Controllers
{
    public class HizmetController : Controller
    {
        // GET: Hizmet
        public ActionResult Index()
        {
            IEnumerable<mvchizmetmodel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("HizmetlerBilgis").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvchizmetmodel>>().Result;
            return View(listele);
            
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvchizmetmodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("HizmetlerBilgis/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvchizmetmodel>().Result);
            }


        }
        [HttpPost]
        public ActionResult EY(mvchizmetmodel hizmet)
        {
            if (hizmet.HizmetNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("HizmetlerBilgis", hizmet).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("HizmetlerBilgis/" + hizmet.HizmetNo, hizmet).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("HizmetlerBilgis/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}
