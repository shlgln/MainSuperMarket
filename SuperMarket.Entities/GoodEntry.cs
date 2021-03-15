using System;
using System.Collections.Generic;
using System.Text;
using SuperMarket.Infrastructure.Domain;

namespace SuperMarket.Entities
{
    public class GoodEntry: Entity<int>
    {
        public int GoodId { get; set; }
        public DateTime EntryDate { get; set; }
        public int GoodCount { get; set; }
    }
}
