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
    public class CPULabelMappingBusinessAccess : ICPULabelMappingBusinessAccess
    {
        private readonly CPULabelMappingDataAccess _cpulabelmappingDataAccess = new CPULabelMappingDataAccess();

        #region public CollectionResult<int> GetAllCPULabelMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<CPULabelMapping> GetAllCPULabelMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<CPULabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<CPULabelMapping>()
            };

            try
            {
                responseData = _cpulabelmappingDataAccess.GetAllCPULabelMapping(Connectionstring, BaseUrl);

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
        #region public CollectionResult<int> GetAllPartDetails(int pageIndex, int pageSize, string search, string Connectionstring) 
        public CollectionResult<CPULabelMapping> GetAllCPULabelMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<CPULabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<CPULabelMapping>()
            };

            try
            {
                responseData = _cpulabelmappingDataAccess.GetAllCPULabelMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);

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

        #region public Result<CPULabelMapping> GetByCPULabelMappingId(int CPULabelMappingId, string Connectionstring, string BaseUrl) 
        public Result<CPULabelMapping> GetByCPULabelMappingId(int CPULabelMappingId, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<CPULabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new CPULabelMapping()

            };

            try
            {
                responseData = _cpulabelmappingDataAccess.GetByCPULabelMappingId(CPULabelMappingId, Connectionstring, BaseUrl);

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

        #region public Result<int> AddorUpdateCPULabelMapping(CPULabelMapping values,string Connectionstring) 
        public Result<int> AddorUpdateCPULabelMapping(CPULabelMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _cpulabelmappingDataAccess.AddorUpdateCPULabelMapping(values, Connectionstring);

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

        #region public Result<int> DeleteCPULabelMapping(CPULabelMapping values, string Connectionstring) 
        public Result<int> DeleteCPULabelMapping(CPULabelMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _cpulabelmappingDataAccess.DeleteCPULabelMapping(values, Connectionstring);

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