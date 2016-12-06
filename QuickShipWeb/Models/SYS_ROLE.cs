namespace QuickShipWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_ROLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_ROLE()
        {
            SYS_USER_ROLE = new HashSet<SYS_USER_ROLE>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string Created_By { get; set; }

        public DateTime Created_Date { get; set; }

        [StringLength(10)]
        public string Modified_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_USER_ROLE> SYS_USER_ROLE { get; set; }
    }
}
