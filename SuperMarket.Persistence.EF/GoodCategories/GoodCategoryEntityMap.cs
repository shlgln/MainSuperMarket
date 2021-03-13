using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.Entities;

namespace SuperMarket.Persistence.EF.GoodCategoies
{
    class GoodCategoryEntityMap : IEntityTypeConfiguration<GoodCategory>
    {
        public void Configure(EntityTypeBuilder<GoodCategory> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .ValueGeneratedOnAdd();

            builder.Property(_ => _.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(_ => _.Goods)
                .WithOne(_ => _.Category)
                .HasForeignKey(_ => _.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
