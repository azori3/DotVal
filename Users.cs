using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webpidev.Models
{
    public class Users
    {
        public string DTYPE { get; set; }

        public int id { get; set; }
 
        public string address { get; set; }

     
        public string mail { get; set; }
 
        public string password { get; set; }

   
        public string region { get; set; }

  
        public string rpassword { get; set; }

      
        public string nameImage { get; set; }

        public int? numTel { get; set; }
 
        public string organsationName { get; set; }

 
        public string type { get; set; }

     
        public string firstName { get; set; }

        
        public string gender { get; set; }
 
        public byte[] image { get; set; }

  
        public string lastName { get; set; }

     
        public string numberAction { get; set; }
 
        public byte[] preferences { get; set; }

    }
}