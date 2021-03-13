using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Services.SalesFactors.Contracts
{
    public class GetSalesFactorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string GoodCode { get; set; }
        public int GoodCount { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
