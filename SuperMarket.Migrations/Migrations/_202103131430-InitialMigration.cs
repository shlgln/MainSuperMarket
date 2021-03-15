using FluentMigrator;
using System;

namespace SuperMarket.Migrations.Migrations
{
    [Migration(202103131430)]
    public class _202103131430_InitialMigration : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("GoodCategories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable();

            Create.Table("Goods")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("Code").AsString(10).NotNullable()
                .WithColumn("CategoryId").AsInt32().NotNullable()
                .ForeignKey("FK_Goods_Category", "GoodCategories", "Id")
                .OnDelete(System.Data.Rule.Cascade)
                .WithColumn("Price").AsInt32().NotNullable()
                .WithColumn("MinimumStack").AsInt32().NotNullable();

            Create.Table("GoodEntries")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("GoodId").AsInt32().NotNullable()
                .WithColumn("EntryDate").AsDateTime()
                .WithColumn("GoodCount").AsInt32().NotNullable();

            Create.Table("SaleFactors")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("GoodId").AsInt32().NotNullable()
                .WithColumn("SalesDate").AsDateTime()
                .WithColumn("GoodCount").AsInt32().NotNullable();


            /*Create.ForeignKey("FK_Goods_Category")
                .FromTable("Goods").ForeignColumn("CategoryId")
                .ToTable("GoodCategories").PrimaryColumn("Id");*/
        }

        public override void Down()
        {
            //Delete.ForeignKey("FK_Goods_Category");
            Delete.Table("Goods");
            Delete.Table("GoodCategories");
            Delete.Table("SaleFactors");
            Delete.Table("GoodEntries");
        }
    }
}
