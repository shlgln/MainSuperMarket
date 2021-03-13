using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Persistence.EF.GoodEntries
{
    public class GoodEntryEntityMap : IEntityTypeConfiguration<GoodEntry>
    {
        public void Configure(EntityTypeBuilder<GoodEntry> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .ValueGeneratedOnAdd();

            builder.Property(_ => _.GoodCode)
                .HasMaxLength(10).IsRequired();

            builder.Property(_ => _.GoodCount).IsRequired();

            builder.Property(_ => _.EntryDate)
                .HasColumnType<DateTime>("datetime");
        }
    }
}
