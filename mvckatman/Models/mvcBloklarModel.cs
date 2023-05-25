using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvckatman.Models
{
    public class mvcBloklarModel
    {
        public int BlokNo { get; set; }
        [Required(ErrorMessage ="Zorunlu Alan")]  
        public string BlokAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
    }
}