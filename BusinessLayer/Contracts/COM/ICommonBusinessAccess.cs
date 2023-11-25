using BusinessModels;
using BusinessModels.COM;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.COM
{
    public interface ICommonBusinessAccess
    {
        Result<CountStatus> GetAllCount(string Connectionstring, string line);
        CollectionResult<AllSeries> GetAllSeriesDetails(string Connectionstring);
        Result<MTBySeries> GetMTBySeries(string Series, string Connectionstring, string BaseUrl);
        Result<GetUserPermissions> GetByRoleIdAccess(int Id, string Connectionstring);
        CollectionResult<ClienDisplaytList> GetClientDropDownList(string Connectionstring);
        public CollectionResult<GetRoles> GetDropDownRoles(string Connectionstring);
        public CollectionResult<GetPartList> GetPartList(string Connectionstring);
        CollectionResult<GetPartByProduct> GetPartByProduct(string Product, string Connectionstring);
        Result<GetRTYProductId> GetRTYProductByMT(string MT, string Connectionstring);
        CollectionResult<GetAllSatge> GetAllStage(string Connectionstring);
        CollectionResult<GetProblemClassList> GetByProblemClass(string ProblemType, string Connectionstring);
        CollectionResult<GetProblemTypeList> GetByProblemType(string PartName, string Connectionstring);
        CollectionResult<GetSolutionTypeList> GetBySolutionType(string PartName, string Connectionstring);
        CollectionResult<GetSolutionClassList> GetBySolutionClass(string SolutionType, string Connectionstring);

        CollectionResult<GetOwnersList> GetByOwners(string UWIP, string Stage, string Connectionstring);

    }
}
