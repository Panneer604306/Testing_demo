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
    public class StageMappingBusinessAccess : IStageMappingBusinessAccess
    {
        private readonly StageMappingDataAccess _stagemappingDataAccess = new StageMappingDataAccess();

        #region public CollectionResult<int> GetAllStageMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<StageMapping> GetAllStageMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<StageMapping>()
            };

            try
            {
                responseData = _stagemappingDataAccess.GetAllStageMapping(Connectionstring, BaseUrl);

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
        public CollectionResult<StageMapping> GetAllStageMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<StageMapping>()
            };

            try
            {
                responseData = _stagemappingDataAccess.GetAllStageMappingDetails(pageIndex, pageSize, search, Connectionstring);

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

        #region public Result<StageMapping> GetByStageMappingId(int StageMappingId, string Connectionstring) 
        public Result<StageMapping> GetByStageMappingId(int Id, string Connectionstring)
        {
            var responseData = new Result<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new StageMapping()

            };

            try
            {
                responseData = _stagemappingDataAccess.GetByStageMappingId(Id, Connectionstring);

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

        #region public Result<Stage> GetLineByClientIP(string ClientIP, string Connectionstring) 
        public Result<StageMapping> GetLineByIPaddress(string IPAddress, string Connectionstring)
        {
            var responseData = new Result<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new StageMapping()

            };

            try
            {
                responseData = _stagemappingDataAccess.GetLineByIPaddress(IPAddress, Connectionstring);

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

        #region public Result<int> AddorUpdateStageMapping(StageMapping values,string Connectionstring) 
        public Result<int> AddorUpdateStageMapping(StageMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _stagemappingDataAccess.AddorUpdateStageMapping(values, Connectionstring);

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

        #region Result<int> DeleteStageMapping(StageMapping values, string Connectionstring);
        public Result<int> DeleteStageMapping(StageMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _stagemappingDataAccess.DeleteStageMapping(values, Connectionstring);

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