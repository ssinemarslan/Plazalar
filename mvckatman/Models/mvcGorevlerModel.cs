using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvckatman.Models
{
    public class mvcGorevlerModel
    {
        public int GorevNo { get; set; }
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string GorevTanimi { get; set; }
    }
}