namespace QuickShipWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SHP_PACKAGE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public long? Delivery_Order_Id { get; set; }

        public byte Status { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        [StringLength(10)]
        public string Modified_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public long SHP_DELIVERY_ORDERId { get; set; }

        public virtual SHP_DELIVERY_ORDER SHP_DELIVERY_ORDER { get; set; }
    }
}
