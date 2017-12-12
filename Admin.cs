using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webpidev.Models
{
    public class Admin
    {

        public int Id { get; set; }


        [StringLength(255)]
        public string mail { get; set; }

        [StringLength(255)]
        public string password { get; set; }
    }
}