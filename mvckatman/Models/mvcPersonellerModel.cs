using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvckatman.Models
{
    public class mvcPersonellerModel
    {
        public int PersonelNo { get; set; }
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string PersonelAdSoyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
    }
}