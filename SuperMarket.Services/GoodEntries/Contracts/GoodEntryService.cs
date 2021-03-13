using SuperMarket.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Services.GoodEntries.Contracts
{
    public interface GoodEntryService: Service
    {
        void AddGoodEntry(AddGoodEntryDto dto);
        IList<GetGoodEntryDto> GetAllGoodEntry();
    }
}
