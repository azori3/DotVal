using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobConsume.Models
{
    public class DonationMvc
    {
        public int id { get; set; }

        public string TitreDonation { get; set; }

        public string TypeDonation { get; set; }

        public string lieuDonation { get; set; }
        public string image { get; set; }
        public string email { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        
        public DateTime? dateajout { get; set; }

     
        public string disponibilite { get; set; }
    }
}