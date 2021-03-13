using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class SaleFactors: Entity<int>
    {
        public string GoodCode { get; set; }
        public DateTime SalesDate { get; set; }
        public int GoodCount { get; set; }
    }
}
