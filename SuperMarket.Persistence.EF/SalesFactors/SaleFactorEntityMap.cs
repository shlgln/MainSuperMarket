using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Persistence.EF.SalesFactors
{
    public class SaleFactorEntityMap: IEntityTypeConfiguration<SaleFactors>
    {
        public void Configure(EntityTypeBuilder<SaleFactors> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id)
                .ValueGeneratedOnAdd();

            builder.Property(_ => _.GoodId).IsRequired();

            builder.Property(_ => _.SalesDate)
                    .HasColumnType<DateTime>("datetime");

            builder.Property(_ => _.GoodCount).IsRequired();
        }
    }
}
