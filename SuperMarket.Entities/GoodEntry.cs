using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Entities
{
    public class GoodEntry
    {
        public int Id { get; set; }
        public string GoodCode { get; set; }
        public DateTime EntryDate { get; set; }
        public int GoodCount { get; set; }
    }
}
