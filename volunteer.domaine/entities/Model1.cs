namespace volunteer.domaine.entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<action> action { get; set; }
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<comment> comment { get; set; }
        public virtual DbSet<donation> donation { get; set; }
        public virtual DbSet<job> job { get; set; }
        public virtual DbSet<message> message { get; set; }
        public virtual DbSet<rating> rating { get; set; }
        public virtual DbSet<signalisation> signalisation { get; set; }
        public virtual DbSet<topic> topic { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<action>()
                .Property(e => e.adresseMapAction)
                .IsUnicode(false);

            modelBuilder.Entity<action>()
                .Property(e => e.discriptionAction)
                .IsUnicode(false);

            modelBuilder.Entity<action>()
                .Property(e => e.imageAction)
                .IsUnicode(false);

            modelBuilder.Entity<action>()
                .Property(e => e.titreAction)
                .IsUnicode(false);

            modelBuilder.Entity<action>()
                .HasMany(e => e.rating)
                .WithRequired(e => e.action)
                .HasForeignKey(e => e.idAction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<action>()
                .HasMany(e => e.users)
                .WithMany(e => e.action)
                .Map(m => m.ToTable("users_action").MapLeftKey("actions_id"));

            modelBuilder.Entity<category>()
                .Property(e => e.contentCat)
                .IsUnicode(false);

            modelBuilder.Entity<comment>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<donation>()
                .Property(e => e.TitreDonation)
                .IsUnicode(false);

            modelBuilder.Entity<donation>()
                .Property(e => e.TypeDonation)
                .IsUnicode(false);

            modelBuilder.Entity<donation>()
                .Property(e => e.lieuDonation)
                .IsUnicode(false);

            modelBuilder.Entity<donation>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<donation>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<donation>()
                .Property(e => e.disponibilite)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.adresseJob)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.contacter)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.contenutJob)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.dureJob)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.indexationJob)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.infosCompl)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.profil)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.recevoirCv)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.titre)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.emailJob)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .Property(e => e.duréeJob)
                .IsUnicode(false);

            modelBuilder.Entity<job>()
                .HasMany(e => e.signalisation)
                .WithOptional(e => e.job)
                .HasForeignKey(e => e.job_id);

            modelBuilder.Entity<message>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<rating>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<signalisation>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<signalisation>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<signalisation>()
                .HasMany(e => e.users1)
                .WithOptional(e => e.signalisation1)
                .HasForeignKey(e => e.signalisation_id);

            modelBuilder.Entity<topic>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.message)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.topic_id);

            modelBuilder.Entity<users>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.category)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.users_id);

            modelBuilder.Entity<users>()
                .HasMany(e => e.comment)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.users_id);

            modelBuilder.Entity<users>()
                .HasMany(e => e.job)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.users_id);

            modelBuilder.Entity<users>()
                .HasMany(e => e.message)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.users_id);

            modelBuilder.Entity<users>()
                .HasMany(e => e.rating)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.idUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.signalisation)
                .WithOptional(e => e.users)
                .HasForeignKey(e => e.users_id);
        }
    }
}
