namespace QuickShipWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_USER_ROLE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [StringLength(8)]
        public string User_Code { get; set; }

        [Required]
        [StringLength(20)]
        public string Role_Code { get; set; }

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

        public long SYS_USERId { get; set; }

        public long SYS_ROLEId { get; set; }

        public virtual SYS_ROLE SYS_ROLE { get; set; }

        public virtual SYS_USER SYS_USER { get; set; }
    }
}
