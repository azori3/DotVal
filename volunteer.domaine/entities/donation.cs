namespace volunteer.domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.donation")]
    public partial class donation
    {
        public int id { get; set; }

        [StringLength(255)]
        public string TitreDonation { get; set; }

        [StringLength(255)]
        public string TypeDonation { get; set; }

        [StringLength(255)]
        public string lieuDonation { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        public DateTime? dateajout { get; set; }

        [StringLength(255)]
        public string disponibilite { get; set; }
    }
}
