namespace SampleProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductsModel : DbContext
    {
        public ProductsModel()
            : base("name=ProductsModel")
        {
        }

        public virtual DbSet<v1Product> v1Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<v1Product>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<v1Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<v1Product>()
                .Property(e => e.SizeUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<v1Product>()
                .Property(e => e.WeightUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<v1Product>()
                .Property(e => e.Weight)
                .HasPrecision(8, 2);

            modelBuilder.Entity<v1Product>()
                .Property(e => e.ProductLine)
                .IsFixedLength();

            modelBuilder.Entity<v1Product>()
                .Property(e => e.Class)
                .IsFixedLength();

            modelBuilder.Entity<v1Product>()
                .Property(e => e.Style)
                .IsFixedLength();
        }
    }
}
