using SuperMarket.Infrastructure.Domain;

namespace SuperMarket.Entities
{
    public class Good:Entity<int>
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int MinimumStack { get; set; }
        public int CategoryId { get; set; }
        public int WareHouseId { get; set; }
        public int Price { get; set; }
        public GoodCategory Category { get; set; }
        public WareHouse WareHouse { get; set; }
    }
}
