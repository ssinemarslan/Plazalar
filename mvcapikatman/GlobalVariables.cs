using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace mvcapikatman
{
    public static class GlobalVariables
    {
        public static HttpClient webapiclient = new HttpClient();
        static GlobalVariables()
        {
            webapiclient.BaseAddress = new Uri("https://localhost:44300/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}