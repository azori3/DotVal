using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webpidev.Models
{
    public class ReportModele
    {

        public int Id { get; set; }


        [StringLength(255)]
        public string mail { get; set; }

        [StringLength(255)]
        public string mailTo { get; set; }

        [StringLength(255)]
        public string Sujet { get; set; }

        public DateTime DateBanneBegin { get; set; }

        public DateTime DateBanneEnd { get; set; }
    }
}