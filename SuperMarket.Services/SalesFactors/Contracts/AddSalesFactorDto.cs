using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Services.SalesFactors.Contracts
{
    public class AddSalesFactorDto
    {
        public int GoodId { get; set; }
        public DateTime SaleDate { get; set; }
        public int GoodCount { get; set; }
    }
}
