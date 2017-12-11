namespace volunteer.domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.comment")]
    public partial class comment
    {
        [Key]
        public int idComment { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public DateTime? dateComment { get; set; }

        public int? users_id { get; set; }

        public virtual users users { get; set; }
    }
}
