namespace QuickShipWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_REGION
    {
        public long Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public long? ZoneId { get; set; }

        public bool IsActive { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string Created_By { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Created_Date { get; set; }

        [StringLength(10)]
        public string Modified_By { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Modified_Date { get; set; }

        public virtual MST_ZONE MST_ZONE { get; set; }
    }
}
