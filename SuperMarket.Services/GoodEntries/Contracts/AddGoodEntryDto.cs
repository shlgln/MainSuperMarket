using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Services.GoodEntries.Contracts
{
    public class AddGoodEntryDto
    {
        public int GoodId { get; set; }
        public DateTime EntryDate { get; set; }
        public int GoodCount { get; set; }
    }
}
