using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcapikatman.Models;
using System.Net.Http;

namespace mvcapikatman.Controllers
{
    public class BlokController : Controller
    {
        // GET: Blok
        public ActionResult Index()
        {
            IEnumerable<mvcblokmodel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("BloklarBilgis").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcblokmodel>>().Result;

            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcblokmodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("BloklarBilgis/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcblokmodel>().Result);

            }
        }
        [HttpPost]
        public ActionResult EY(mvcblokmodel blok)
        {
            if (blok.BlokNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("BloklarBilgis", blok).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("BloklarBilgis/" + blok.BlokNo, blok).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("BloklarBilgis/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}