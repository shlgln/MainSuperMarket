using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Services.Goods.Contracts
{
    public class UpdateGoodDto
    {
        public string Title { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
