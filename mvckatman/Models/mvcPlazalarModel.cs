using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvckatman.Models
{
    public class mvcPlazalarModel
    {
        public int PlazaNo { get; set; }
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string PlazaAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
    }
}