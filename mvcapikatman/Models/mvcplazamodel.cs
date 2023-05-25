using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcapikatman.Models
{
    public class mvcplazamodel
    {
        public int PlazaNo { get; set; }
        public string PlazaAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
    }
}