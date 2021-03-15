﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Services.Goods.Contracts
{
    public class AddGoodDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int WareHouseId { get; set; }
        public int MinimumStack { get; set; }
    }
}
