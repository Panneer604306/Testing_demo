using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface IOSLabelMappingDataAccess
    {
        CollectionResult<OSLabelMapping> GetAllOSLabelMapping(string Connectionstring, string BaseUrl);
        CollectionResult<OSLabelMapping> GetAllOSLabelMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl);

        Result<OSLabelMapping> GetByOSLabelMappingId(int Id, string Connectionstring, string BaseUrl);

        Result<int> AddorUpdateOSLabelMapping(OSLabelMapping values, string Connectionstring);

        Result<int> DeleteOSLabelMapping(OSLabelMapping values, string Connectionstring);
    }
}
