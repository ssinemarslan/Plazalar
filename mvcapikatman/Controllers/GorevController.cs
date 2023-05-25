using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcapikatman.Models;
using System.Net.Http;

namespace mvcapikatman.Controllers
{
    public class GorevController : Controller
    {
        // GET: Gorev
        public ActionResult Index()
        {
            IEnumerable<mvcgorevmodel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("GorevlerBilgis").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcgorevmodel>>().Result;
            return View(listele);
            
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcgorevmodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("GorevlerBilgis/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcgorevmodel>().Result);
            }


        }
        [HttpPost]
        public ActionResult EY(mvcgorevmodel gorev)
        {
            if (gorev.GorevNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("GorevlerBilgis", gorev).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("GorevlerBilgis/" + gorev.GorevNo, gorev).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("GorevlerBilgis/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}
