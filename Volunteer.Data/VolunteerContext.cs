using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using volunteer.domaine.entities;
using Volunteer.Data.Configurations;



namespace Volunteer.Data
{
  //  [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public  class VolunteerContext : DbContext
    { 
        static VolunteerContext()
        {
            Database.SetInitializer<VolunteerContext>(null);
        }
        public VolunteerContext():base("name=Volunteer")
        {
        }

        public  DbSet<action> action { get; set; }
        public  DbSet<category> category { get; set; }
        public  DbSet<comment> comment { get; set; }
        public  DbSet<donation> donation { get; set; }
        public  DbSet<job> job { get; set; }
        public  DbSet<message> message { get; set; }
        public  DbSet<rating> rating { get; set; }
        public  DbSet<signalisation> signalisation { get; set; }
        public  DbSet<topic> topic { get; set; }
        public  DbSet<users> users { get; set; }

      //  public System.Data.Entity.DbSet<JobConsume.Models.DonationMvc> DonationMvcs { get; set; }

        //   public System.Data.Entity.DbSet<JobConsume.Models.DonationMvc> DonationMvcs { get; set; }

        //   public DbSet<JobConsume.Models.DonationMvc> DonationMvcs { get; set; }
        //public DbSet<donation> DonationMvcs { get; set; }
        ////protected override void OnModelCreating(DbModelBuilder modelBuilder)
        ////{
        ////    modelBuilder.Configurations.Add(new donationMap());
        ////}


    }

    }

