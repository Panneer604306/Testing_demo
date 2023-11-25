using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IProblemClassBusinessAccess
    {
        CollectionResult<ProblemClass> GetAllProblemClass(string Connectionstring, string BaseUrl);

        CollectionResult<ProblemClass> GetAllProblemClassDetails(int pageIndex, int pageSize, string search, string Connectionstring);

        Result<ProblemClass> GetByProblemClassId(int Id, string Connectionstring);

        Result<int> AddorUpdateProblemClass(ProblemClass values, string Connectionstring);

        Result<int> DeleteProblemClass(ProblemClass values, string Connectionstring);
    }
}
