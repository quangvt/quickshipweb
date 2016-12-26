namespace QuickShipWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeFirstDBContext : DbContext
    {
        public CodeFirstDBContext()
            : base("name=CodeFirstDBContextConnString")
        {
        }

        public virtual DbSet<MST_CUSTOMER> MST_CUSTOMER { get; set; }
        public virtual DbSet<MST_LOCATION> MST_LOCATION { get; set; }
        public virtual DbSet<SHP_DELIVERY_ORDER> SHP_DELIVERY_ORDER { get; set; }
        public virtual DbSet<SHP_PACKAGE> SHP_PACKAGE { get; set; }
        public virtual DbSet<MST_ZONE> MST_ZONE { get; set; }
        public virtual DbSet<MST_REGION> MST_REGION { get; set; }
        public virtual DbSet<SYS_ROLE> SYS_ROLE { get; set; }
        public virtual DbSet<SYS_USER> SYS_USER { get; set; }
        public virtual DbSet<SYS_USER_ROLE> SYS_USER_ROLE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SHP_DELIVERY_ORDER>()
                .Property(e => e.Begin_Amount)
                .HasPrecision(12, 0);

            modelBuilder.Entity<SHP_DELIVERY_ORDER>()
                .Property(e => e.Final_Amount)
                .HasPrecision(12, 0);

            modelBuilder.Entity<SHP_DELIVERY_ORDER>()
                .HasMany(e => e.SHP_PACKAGE)
                .WithRequired(e => e.SHP_DELIVERY_ORDER)
                .HasForeignKey(e => e.Delivery_Order_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYS_ROLE>()
                .HasMany(e => e.SYS_USER_ROLE)
                .WithRequired(e => e.SYS_ROLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYS_USER>()
                .HasMany(e => e.SYS_USER_ROLE)
                .WithRequired(e => e.SYS_USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_ZONE>()
               .HasMany(e => e.MST_REGION)
               .WithOptional(e => e.MST_ZONE)
               .HasForeignKey(e => e.ZoneId);
        }
    }
}
