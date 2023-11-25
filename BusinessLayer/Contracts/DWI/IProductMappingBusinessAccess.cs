using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IProductMappingBusinessAccess
    {
        CollectionResult<ProductMapping> GetAllProductMapping(string Connectionstring, string BaseUrl);

        CollectionResult<ProductMapping> GetAllProductMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring);

        Result<ProductMapping> GetByProductMappingId(int Id, string Connectionstring);

        Result<int> AddorUpdateProductMapping(ProductMapping values, string Connectionstring);

        Result<int> DeleteProductMapping(ProductMapping values, string Connectionstring);
    }
}
