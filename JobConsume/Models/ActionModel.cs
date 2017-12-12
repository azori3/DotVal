using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapp.Models
{
    public class ActionModel
    {
        public int idAction { get; set; }
        public DateTime? dateDebutAction { get; set; }

      
        public DateTime? dateFinAction { get; set; }

       
        public string discriptionAction { get; set; }

       
        public string imageAction { get; set; }

       
        public string titreAction { get; set; }

        public int localisation { get; set; }

        public int? user_id { get; set; }

        public float lag { get; set; }
        public float lat { get; set; }
        public String urlImage { get; set; }
    }
}