namespace volunteer.domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.signalisation")]
    public partial class signalisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public signalisation()
        {
            users1 = new HashSet<users>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        public int? job_id { get; set; }

        public int? users_id { get; set; }

        public virtual job job { get; set; }

        public virtual users users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users> users1 { get; set; }
    }
}
