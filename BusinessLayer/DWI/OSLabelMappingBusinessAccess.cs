using BusinessModels;
using BusinessModels.DWI;
using DataLayer.DWI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer.DWI
{


    public class OSLabelMappingBusinessAccess : IOSLabelMappingBusinessAccess
    {
        private readonly OSLabelMappingDataAccess _oslabelmappingDataAccess = new OSLabelMappingDataAccess();

        #region public CollectionResult<int> GetAllOSLabelMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<OSLabelMapping> GetAllOSLabelMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<OSLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<OSLabelMapping>()
            };

            try
            {
                responseData = _oslabelmappingDataAccess.GetAllOSLabelMapping(Connectionstring, BaseUrl);

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
        public CollectionResult<OSLabelMapping> GetAllOSLabelMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<OSLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<OSLabelMapping>()
            };

            try
            {
                responseData = _oslabelmappingDataAccess.GetAllOSLabelMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);

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

        #region public Result<OSLabelMapping> GetByOSLabelMappingId(int OSLabelMappingId, string Connectionstring,string BaseUrl) 
        public Result<OSLabelMapping> GetByOSLabelMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<OSLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new OSLabelMapping()

            };

            try
            {
                responseData = _oslabelmappingDataAccess.GetByOSLabelMappingId(Id, Connectionstring, BaseUrl);

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

        #region public Result<int> AddorUpdateOSLabelMapping(OSLabelMapping values,string Connectionstring) 
        public Result<int> AddorUpdateOSLabelMapping(OSLabelMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _oslabelmappingDataAccess.AddorUpdateOSLabelMapping(values, Connectionstring);

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

        #region Result<int> DeleteOSLabelMapping(OSLabelMapping values, string Connectionstring);
        public Result<int> DeleteOSLabelMapping(OSLabelMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _oslabelmappingDataAccess.DeleteOSLabelMapping(values, Connectionstring);

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