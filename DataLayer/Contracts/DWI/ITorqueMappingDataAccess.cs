using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface ITorqueMappingDataAccess
    {
        CollectionResult<TorqueMapping> GetAllTorqueMapping(string Connectionstring, string BaseUrl);

        CollectionResult<TorqueMapping> GetAllTorqueMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl);

        Result<TorqueMapping> GetByTorqueMappingId(int Id, string Connectionstring, string BaseUrl);

        Result<int> AddorUpdateTorqueMapping(TorqueMapping values, string Connectionstring);

        Result<int> DeleteTorqueMapping(TorqueMapping values, string Connectionstring);
    }
}
