using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class WareHouse: Entity<int>
    {
        public int GoodId { get; set; }
        public int GoodCount { get; set; }

        public List<Good> goods { get; set; }
    }
}
