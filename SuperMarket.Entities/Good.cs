using SuperMarket.Infrastructure.Domain;

namespace SuperMarket.Entities
{
    public class Good:Entity<int>
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }

        public GoodCategory Category { get; set; }

        public string Status
        {
            get
            {
                return Count == 0 ? "Unavailable" : "available";
            }
        }
    }
}
