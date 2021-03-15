using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class WareHouse: Entity<int>
    {
        public string Name { get; set; }
        public int GoodCount { get; set; }
        public List<Good> Goods { get; set; }
    }
}
