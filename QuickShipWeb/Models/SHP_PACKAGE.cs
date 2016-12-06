namespace QuickShipWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SHP_PACKAGE
    {
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Delivery Order Id")]
        public long Delivery_Order_Id { get; set; }

        public byte Status { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Created By")]
        public string Created_By { get; set; }

        [Display(Name = "Created Date")]
        public DateTime Created_Date { get; set; }

        [StringLength(10)]
        [Display(Name = "Modified By")]
        public string Modified_By { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? Modified_Date { get; set; }

        public virtual SHP_DELIVERY_ORDER SHP_DELIVERY_ORDER { get; set; }
    }
}
