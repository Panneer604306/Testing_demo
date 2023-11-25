using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IClientBusinessAccess
    {
        CollectionResult<GetStageList> GetStageList(string Connectionstring);

        CollectionResult<GetClientDisplay> GetClientDisplay(string Connectionstring);

        Result<Client> GetManualByClient(string MT, string Connectionstring, string BaseUrl);

        Result<Client> GetLiveByClient(string MT, string Tiny, string Display, string Connectionstring, string BaseUrl);

    }
}
