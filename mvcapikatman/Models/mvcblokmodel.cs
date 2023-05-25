using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcapikatman.Models
{
    public class mvcblokmodel
    {
        public int BlokNo { get; set; }
        public string BlokAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
    }
}