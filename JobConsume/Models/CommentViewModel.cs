namespace VolunteersPidev.web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("pidevdb.comment")]
    public  class CommentViewModel

    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string content { get; set; }
        public DateTime? dateComment { get; set; }
        public int comment_like { get; set; }

        public int note { get; set; }

        public IEnumerable<SelectListItem> Notes { get; set; }

        public int? action_idAction { get; set; }
        public int? users_id { get; set; }
    }
}
