using BusinessLayer.Contracts.DWI;
using BusinessModels;
using BusinessModels.DWI;
using DataLayer.DWI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer.DWI
{
    public class ProductMappingBusinessAccess : IProductMappingBusinessAccess
    {
        private readonly ProductMappingDataAccess _ProductMappingDataAccess = new ProductMappingDataAccess();

        #region public CollectionResult<int> GetAllProductMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<ProductMapping> GetAllProductMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<ProductMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProductMapping>()
            };

            try
            {
                responseData = _ProductMappingDataAccess.GetAllProductMapping(Connectionstring, BaseUrl);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion
        #region public CollectionResult<int> GetAllPartDetails(string Connectionstring) 
        public CollectionResult<ProductMapping> GetAllProductMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<ProductMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProductMapping>()
            };

            try
            {
                responseData = _ProductMappingDataAccess.GetAllProductMappingDetails(pageIndex, pageSize, search, Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public Result<ProductMapping> GetByProductMappingId(int Id, string Connectionstring) 
        public Result<ProductMapping> GetByProductMappingId(int Id, string Connectionstring)
        {
            var responseData = new Result<ProductMapping>
            {
                Status = true,
                Message = default(string),
                Data = new ProductMapping()

            };

            try
            {
                responseData = _ProductMappingDataAccess.GetByProductMappingId(Id, Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion



        #region public Result<int> AddorUpdateProductMapping(ProductMapping values,string Connectionstring) 
        public Result<int> AddorUpdateProductMapping(ProductMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _ProductMappingDataAccess.AddorUpdateProductMapping(values, Connectionstring);

                if (!result.Status)
                {
                    throw new Exception(result.Message);
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
        #endregion

        #region Result<int> DeleteProductMapping(ProductMapping values, string Connectionstring);
        public Result<int> DeleteProductMapping(ProductMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _ProductMappingDataAccess.DeleteProductMapping(values, Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion
    }
}