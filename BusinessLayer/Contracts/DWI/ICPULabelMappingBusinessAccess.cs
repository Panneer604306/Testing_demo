using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface ICPULabelMappingBusinessAccess
    {
        CollectionResult<CPULabelMapping> GetAllCPULabelMapping(string Connectionstring, string BaseUrl);
        CollectionResult<CPULabelMapping> GetAllCPULabelMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl);

        Result<CPULabelMapping> GetByCPULabelMappingId(int CPULabelMappingId, string Connectionstring, string BaseUrl);

        Result<int> AddorUpdateCPULabelMapping(CPULabelMapping values, string Connectionstring);

        Result<int> DeleteCPULabelMapping(CPULabelMapping values, string Connectionstring);
    }
}
