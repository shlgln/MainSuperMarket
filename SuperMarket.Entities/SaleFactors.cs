using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class SaleFactors
    {
        public int Id { get; set; }
        public string GoodCode { get; set; }
        public DateTime SalesDate { get; set; }
        public int GoodCount { get; set; }
    }
}
