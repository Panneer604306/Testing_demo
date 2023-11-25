using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
  public interface IPartPicMappingBusinessAccess
  {
    CollectionResult<PartPicMapping> GetAllPartPicMapping(string Connectionstring, string BaseUrl);
    CollectionResult<PartPicMapping> GetAllPartPicMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl);
    Result<PartPicMapping> GetByPartPicMappingId(int Id, string Connectionstring, string BaseUrl);
    Result<int> AddorUpdatePartPicMapping(PartPicMapping values, string Connectionstring);

    Result<int> DeletePartPicMapping(PartPicMapping values, string Connectionstring);
  }
}
