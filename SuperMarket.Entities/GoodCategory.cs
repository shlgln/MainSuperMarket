using SuperMarket.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class GoodCategory: Entity<int>
    {
        public string Title { get; set; }
        public List<Good> Goods { get; set; }
    }
}
