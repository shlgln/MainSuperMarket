using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Services.GoodEntries.Contracts
{
    public class GetGoodEntryDto
    {
        public int Id { get; set; }
        public string GoodTitle { get; set; }
        public string CategoryTitle { get; set; }
        public string GoodCode { get; set; }
        public DateTime EntryDate { get; set; }
        public int GoodCount { get; set; }
    }
}
