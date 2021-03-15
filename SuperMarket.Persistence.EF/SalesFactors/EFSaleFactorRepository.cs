using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.SalesFactors.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Persistence.EF.SalesFactors
{
    public class EFSaleFactorRepository : SaleFactorRepository
    {
        private readonly EFDataContext _dataContext;
        public EFSaleFactorRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddSaleFactor(SaleFactors salesFactors)
        {
             _dataContext.SaleFactors.AddAsync(salesFactors);
        }

        public async Task<IList<GetSalesFactorDto>> GetAllSaleFactors()
        {
            var query = from s in _dataContext.SaleFactors
                        join g in _dataContext.Goods on s.GoodCode equals g.Code
                        select new GetSalesFactorDto
                        {
                            Id = s.Id,
                            Title = g.Title,
                            GoodCode = s.GoodCode,
                            GoodCount = s.GoodCount,
                            SaleDate = s.SalesDate
                        };
            return await query.ToListAsync();
        }
    }
}
