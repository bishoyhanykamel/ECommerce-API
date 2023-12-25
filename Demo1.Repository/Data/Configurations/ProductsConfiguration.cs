using Demo1.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Repository.Data.Configurations
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.ProductType).WithMany()
                .HasForeignKey(P => P.TypeId);
            builder.HasOne(P => P.ProductBrand).WithMany()
                .HasForeignKey(P => P.BrandId);
            builder.Property(P => P.Name).IsRequired();
            builder.Property(P => P.Price).IsRequired();
        }
    }
}
