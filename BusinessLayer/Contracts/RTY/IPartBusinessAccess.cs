using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BusinessModels;
using DataLayer;

namespace BusinessLayer.Contracts
{
    public interface IPartBusinessAccess
    {
        CollectionResult<Part> GetAllPart(string Connectionstring, string BaseUrl);

        CollectionResult<Part> GetAllPartDetails(int pageIndex, int pageSize, string search, string Connectionstring);

        Result<Part> GetByPartId(int Id, string Connectionstring);

        Result<int> AddorUpdatePart(Part values, string Connectionstring);

        Result<int> DeletePart(Part values, string Connectionstring);
    }
}
