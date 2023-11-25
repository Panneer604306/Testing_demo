using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface IProductMappingDataAccess
    {
        CollectionResult<ProductMapping> GetAllProductMapping(string Connectionstring, string BaseUrl);

        CollectionResult<ProductMapping> GetAllProductMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring);

        Result<OSLabelMapping> GetByProductMappingId(int Id, string Connectionstring);

        Result<int> AddorUpdateProductMapping(ProductMapping values, string Connectionstring);

        Result<int> DeleteProductMapping(ProductMapping values, string Connectionstring);
    }
}
