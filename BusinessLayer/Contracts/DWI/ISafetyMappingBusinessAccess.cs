using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface ISafetyMappingBusinessAccess
    {
        CollectionResult<SafetyMapping> GetAllSafetyMapping(string Connectionstring, string BaseUrl);
        Result<int> GetSafetyInsertedDetails(Safety values, string Connectionstring);

        Result<int> AddorUpdateSafetyDetails(SafetyMapping values, string Connectionstring);

        CollectionResult<SafetyMapping> GetAllSafetyDetails(int PageIndex, int PageSize, string search, string Connectionstring, string BaseUrl);

        Result<SafetyMapping> GetBySafetyId(int Id, string Connectionstring, string BaseUrl);

        Result<int> DeleteSafetyDetails(SafetyMapping values, string Connectionstring);
    }
}
