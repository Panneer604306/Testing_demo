using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface ISolutionClassBusinessAccess
    {
        CollectionResult<SolutionClass> GetAllSolutionClass(string Connectionstring, string BaseUrl);
        CollectionResult<SolutionClass> GetAllSolutionClassDetails(int pageIndex, int pageSize, string search, string Connectionstring);
        Result<SolutionClass> GetBySolutionClassId(int Id, string Connectionstring);
        Result<int> AddorUpdateSolutionClass(SolutionClass values, string Connectionstring);
        Result<int> DeleteSolutionClass(SolutionClass values, string Connectionstring);
    }
}
