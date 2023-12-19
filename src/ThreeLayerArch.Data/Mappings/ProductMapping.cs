using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.Data.Mappings
{
	public class ProductMapping : IEntityTypeConfiguration<Product>
	{
		public ProductMapping()
		{
		}

		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasColumnType("varchar(200)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.ToTable("Products");
        }
	}
}

