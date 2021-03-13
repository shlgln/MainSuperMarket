namespace SuperMarket.Services.Goods.Contracts
{
    public class GetGoodDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; }
    }
}
