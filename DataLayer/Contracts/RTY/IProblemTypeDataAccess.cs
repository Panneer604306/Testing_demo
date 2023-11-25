using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface IProblemTypeDataAccess
    {
        CollectionResult<ProblemType> GetAllProblemType(string Connectionstring, string BaseUrl);
        CollectionResult<ProblemType> GetAllProblemTypeDetails(int pageIndex, int pageSize, string search, string Connectionstring);
        Result<ProblemType> GetByProblemTypeId(int Id, string Connectionstring);
        Result<int> AddorUpdateProblemType(ProblemType values, string Connectionstring);
        Result<int> DeleteProblemType(ProblemType values, string Connectionstring);
    }
}
