using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using SuperMarket.Services.SalesFactors.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket.Persistence.EF.SalesFactors
{
    public class EFSaleFactorRepository : SaleFactorRepository
    {
        private readonly EFDataContext _dataContext;
        private readonly DbSet<SaleFactors> _set;
        public EFSaleFactorRepository(EFDataContext dataContext)
        {
            _dataContext = dataContext;
            _set = _dataContext.SaleFactors;
        }
        public void Add(SaleFactors salesFactors)
        {
            _dataContext.Add(salesFactors);
        }

        public IList<GetSalesFactorDto> GetAll()
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
            return query.ToList();
        }
    }
}
