using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Persistence.EF.WareHouses
{
    public class WareHouseEntityMap : IEntityTypeConfiguration<WareHouse>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WareHouse> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .ValueGeneratedOnAdd();

            builder.Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(_ => _.Goods)
                .WithOne(_ => _.WareHouse)
                .HasForeignKey(_ => _.WareHouseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
