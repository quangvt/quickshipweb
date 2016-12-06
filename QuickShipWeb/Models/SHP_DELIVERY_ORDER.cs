namespace QuickShipWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SHP_DELIVERY_ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHP_DELIVERY_ORDER()
        {
            SHP_PACKAGE = new HashSet<SHP_PACKAGE>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Delivery Order No.")]
        public string Delivery_Order { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Customer Code")]
        public string Customer_Code { get; set; }

        [Required]
        [StringLength(8)]
        [Display(Name = "Location Code")]
        public string Location_Code { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Create Order Date")]
        public DateTime? Create_Order_Date { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Assign Order Date")]
        public DateTime? Assign_Order_Date { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Onroad Order Date")]
        public DateTime? Onroad_Order_Date { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Finish Order Date")]
        public DateTime? Finish_Order_Date { get; set; }

        [Display(Name = "Begin Amount")]
        public decimal? Begin_Amount { get; set; }

        [Display(Name = "Final Amount")]
        public decimal? Final_Amount { get; set; }

        public byte Status { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        [StringLength(255)]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHP_PACKAGE> SHP_PACKAGE { get; set; }
    }
}
