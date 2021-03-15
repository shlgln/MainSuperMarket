using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Migrations.Migrations
{
    [Migration(202103141005)]
    public class _202103141005_AddingWareHouse : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("WareHouses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("GoodCount").AsInt32().Nullable()
                .WithColumn("Name").AsString().NotNullable();

           

            Alter.Table("Goods")
               .AddColumn("WareHouseId").AsInt32().NotNullable()
               .ForeignKey("FK_Ware_House", "WareHouses", "Id")
               .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Column("WareHouseId").FromTable("Goods").InSchema("Pricing");
            Delete.Table("WareHouses");
        }

    }
}
