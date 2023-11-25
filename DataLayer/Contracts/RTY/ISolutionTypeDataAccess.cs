using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface ISolutionTypeDataAccess
    {
        CollectionResult<SolutionType> GetAllSolutionType(string Connectionstring, string BaseUrl);
        CollectionResult<SolutionType> GetAllSolutionTypeDetails(int pageIndex, int pageSize, string search, string Connectionstring);
        Result<SolutionType> GetBySolutionTypeId(int Id, string Connectionstring);
        Result<int> AddorUpdateSolutionType(SolutionType values, string Connectionstring);
        Result<int> DeleteSolutionType(SolutionType values, string Connectionstring);
    }
}
