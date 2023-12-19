using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.Data.Mappings
{
	public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
		public SupplierMapping()
		{
		}

        public void Configure(EntityTypeBuilder<Supplier> builder)
		{
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.HasOne(x => x.Address)
                .WithOne(x => x.Supplier);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Supplier)
                .HasForeignKey(x => x.SupplierId);

            builder.ToTable("Suppliers");
        }

    }

}
