namespace volunteer.domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.message")]
    public partial class message
    {
        [Key]
        public int idMessage { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public DateTime? date { get; set; }

        public int? topic_id { get; set; }

        public int? users_id { get; set; }

        public virtual users users { get; set; }

        public virtual topic topic { get; set; }
    }
}
