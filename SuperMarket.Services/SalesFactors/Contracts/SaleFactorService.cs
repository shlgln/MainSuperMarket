using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.SalesFactors.Contracts
{
    public interface SaleFactorService: Service
    {
        public void Add(AddSalesFactorDto dto);

        public IList<GetSalesFactorDto> GetAll();
    }
}
