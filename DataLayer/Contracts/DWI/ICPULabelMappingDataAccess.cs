using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface ICPULabelMappingDataAccess
    {
        CollectionResult<CPULabelMapping> GetAllCPULabelMapping(string Connectionstring, string BaseUrl);

        CollectionResult<CPULabelMapping> GetAllCPULabelMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl);

        Result<CPULabelMapping> GetByCPULabelMappingId(int CPULabelMappingId, string Connectionstring, string BaseUrl);

        Result<int> AddorUpdateCPULabelMapping(CPULabelMapping values, string Connectionstring);

        Result<int> DeleteCPULabelMapping(CPULabelMapping values, string Connectionstring);
    }
}
