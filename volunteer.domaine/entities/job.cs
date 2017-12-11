namespace volunteer.domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.job")]
    public partial class job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public job()
        {
            signalisation = new HashSet<signalisation>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string adresseJob { get; set; }

        [StringLength(255)]
        public string contacter { get; set; }

        [StringLength(255)]
        public string contenutJob { get; set; }

        public DateTime? dateDebJob { get; set; }

        [StringLength(255)]
        public string dureJob { get; set; }

        public DateTime? finDePublication { get; set; }

        [StringLength(255)]
        public string indexationJob { get; set; }

        [StringLength(255)]
        public string infosCompl { get; set; }

        public int nbrPOste { get; set; }

        [StringLength(255)]
        public string profil { get; set; }

        [StringLength(255)]
        public string recevoirCv { get; set; }

        public int? servActivite { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        public int? typeContrat { get; set; }

        public int? users_id { get; set; }

        [StringLength(255)]
        public string emailJob { get; set; }

        [StringLength(255)]
        public string duréeJob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<signalisation> signalisation { get; set; }

        public virtual users users { get; set; }
    }
}
