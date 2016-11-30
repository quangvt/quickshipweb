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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Delivery_Order { get; set; }

        [Required]
        [StringLength(8)]
        public string Customer_Code { get; set; }

        public DateTime? Create_Order_Date { get; set; }

        public DateTime? Assign_Order_Date { get; set; }

        public DateTime? Onroad_Order_Date { get; set; }

        public DateTime? Finish_Order_Date { get; set; }

        public decimal? Begin_Amount { get; set; }

        public decimal? Final_Amount { get; set; }

        public byte Status { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        [StringLength(10)]
        public string Modified_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        [Required]
        [StringLength(8)]
        public string Location_Code { get; set; }

        public long MST_CUSTOMERId { get; set; }

        public long MST_LOCATIONId { get; set; }

        public virtual MST_CUSTOMER MST_CUSTOMER { get; set; }

        public virtual MST_LOCATION MST_LOCATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHP_PACKAGE> SHP_PACKAGE { get; set; }
    }
}
