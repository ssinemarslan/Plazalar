using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcapikatman.Models;
using System.Net.Http;

namespace mvcapikatman.Controllers
{
    public class PlazalarController : Controller
    {
        // GET: Plazaalar
        public ActionResult Index()
        {
            IEnumerable<mvcplazamodel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("PlazalarBilgis").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcplazamodel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcplazamodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("PlazalarBilgis/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcplazamodel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(mvcplazamodel plaza)
        {
            if (plaza.PlazaNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("PlazalarBilgis", plaza).Result;

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("PlazalarBilgis/" + plaza.PlazaNo, plaza).Result;

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("PlazalarBilgis/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}