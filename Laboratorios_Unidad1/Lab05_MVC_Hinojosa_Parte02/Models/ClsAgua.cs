using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab05_MVC_Hinojosa.Models
{
    public class ClsAgua
    {
        [Required]
        [Display(Name = "Litros")]
        public int litros { get; set; }
    }
}