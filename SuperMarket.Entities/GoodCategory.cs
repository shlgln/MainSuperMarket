using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class GoodCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Good> Goods { get; set; }
    }
}
