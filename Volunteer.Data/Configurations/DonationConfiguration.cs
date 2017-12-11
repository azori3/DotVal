using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using volunteer.domaine.entities;

namespace Volunteer.Data.Configurations
{
  public  class DonationConfiguration:EntityTypeConfiguration<donation>

    {
        public DonationConfiguration()
        {
            ToTable("donation");
            HasKey(c => c.id);

        }


    }
}
