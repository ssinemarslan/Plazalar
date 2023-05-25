using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcapikatman.Models
{
    public class mvcpersonelmodel
    {
        public int PersonelNo { get; set; }
        public string PersonelAdSoyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
    }
}