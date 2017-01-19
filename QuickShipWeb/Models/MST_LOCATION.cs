namespace QuickShipWeb.Models
{
    using Helpers1;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_LOCATION
    {
        public long Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name="Active")]
        public bool IsActive { get; set; }

        [StringLength(255)]
        [DataType(DataType.MultilineText)]
        [MaxWords(3)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Created By")]
        public string Created_By { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Created Date")]
        public DateTime Created_Date { get; set; }

        [StringLength(10)]
        [Display(Name = "Modified By")]
        public string Modified_By { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Modified Date")]
        public DateTime? Modified_Date { get; set; }
    }
}
