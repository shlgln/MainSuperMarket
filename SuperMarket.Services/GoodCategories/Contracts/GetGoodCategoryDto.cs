using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Services.GoodCategories.Contracts
{
    public class GetGoodCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> goods { get; set; }
    }
}
