namespace volunteer.domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.action")]
    public partial class action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public action()
        {
            rating = new HashSet<rating>();
            users = new HashSet<users>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string adresseMapAction { get; set; }

        public DateTime? dateDebutAction { get; set; }

        public DateTime? dateFinAction { get; set; }

        [StringLength(255)]
        public string discriptionAction { get; set; }

        [StringLength(255)]
        public string imageAction { get; set; }

        [StringLength(255)]
        public string titreAction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rating> rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users> users { get; set; }
    }
}
