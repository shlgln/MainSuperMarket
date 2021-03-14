using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.SalesFactors.Contracts
{
    public interface SaleFactorService: Service
    {
        public void AddSaleFactor(AddSalesFactorDto dto);

        public IList<GetSalesFactorDto> GetAllSaleFactors();
    }
}
