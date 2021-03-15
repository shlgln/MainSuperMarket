using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Migrations.Migrations
{
    [Migration(2021031501605)]
    public class _2021031501605_chngetypeofpriceingoodetodesimal : FluentMigrator.Migration
    {
        public override void Up()
        {
            Alter.Table("Goods").AlterColumn("Price").AsDecimal().NotNullable();
        }
        public override void Down()
        {
            Alter.Table("Goods").AlterColumn("Price").AsInt32().NotNullable();
        }
    }
}
