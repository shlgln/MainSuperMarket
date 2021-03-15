using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Persistence.EF.Goods
{
    public class GoodEntityMap : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).ValueGeneratedOnAdd();

            builder.Property(_ => _.Title).HasMaxLength(50).IsRequired();

            builder.Property(_ => _.MinimumStack).IsRequired();

            builder.Property(_ => _.WareHouseId).IsRequired();

            builder.Property(_ => _.CategoryId).IsRequired();

            builder.Property(_ => _.Price).IsRequired();


            builder.HasOne(_ => _.Category)
                .WithMany(_ => _.Goods)
                .HasForeignKey(_ => _.CategoryId);

            builder.HasOne(_ => _.WareHouse)
                .WithMany(_ => _.Goods)
                .HasForeignKey(_ => _.WareHouse);
        }
    }
}
