namespace volunteer.domaine.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.category")]
    public partial class category
    {
        [Key]
        public int idCategory { get; set; }

        [StringLength(255)]
        public string contentCat { get; set; }

        public int? users_id { get; set; }

        public virtual users users { get; set; }
    }
}
