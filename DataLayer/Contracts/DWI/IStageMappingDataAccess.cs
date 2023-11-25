using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface IStageMappingDataAccess
    {
        CollectionResult<StageMapping> GetAllStageMapping(string Connectionstring, string BaseUrl);
        CollectionResult<StageMapping> GetAllStageMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring);

        Result<StageMapping> GetByStageMappingId(int Id, string Connectionstring);

        Result<StageMapping> GetLineByIPaddress(string IPAddress, string Connectionstring);

        Result<int> AddorUpdateStageMapping(StageMapping values, string Connectionstring);

        Result<int> DeleteStageMapping(StageMapping values, string Connectionstring);
    }
}
