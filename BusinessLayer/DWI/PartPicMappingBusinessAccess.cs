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
    public class PartPicMappingBusinessAccess : IPartPicMappingBusinessAccess
    {
        private readonly PartPicMappingDataAccess _partpicmappingDataAccess = new PartPicMappingDataAccess();

        #region public CollectionResult<int> GetAllPartPicMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<PartPicMapping> GetAllPartPicMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<PartPicMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<PartPicMapping>()
            };

            try
            {
                responseData = _partpicmappingDataAccess.GetAllPartPicMapping(Connectionstring, BaseUrl);

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
        public CollectionResult<PartPicMapping> GetAllPartPicMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<PartPicMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<PartPicMapping>()
            };

            try
            {
                responseData = _partpicmappingDataAccess.GetAllPartPicMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);

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

        #region public Result<PartPicMapping> GetByPartPicMappingId(int Id, string Connectionstring) 
        public Result<PartPicMapping> GetByPartPicMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<PartPicMapping>
            {
                Status = true,
                Message = default(string),
                Data = new PartPicMapping()

            };

            try
            {
                responseData = _partpicmappingDataAccess.GetByPartPicMappingId(Id, Connectionstring, BaseUrl);

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

        #region public Result<int> AddorUpdatePartPicMapping(PartPicMapping values,string Connectionstring) 
        public Result<int> AddorUpdatePartPicMapping(PartPicMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _partpicmappingDataAccess.AddorUpdatePartPicMapping(values, Connectionstring);

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

        #region Result<int> DeletePartPicMapping(PartPicMapping values, string Connectionstring);
        public Result<int> DeletePartPicMapping(PartPicMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _partpicmappingDataAccess.DeletePartPicMapping(values, Connectionstring);

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
