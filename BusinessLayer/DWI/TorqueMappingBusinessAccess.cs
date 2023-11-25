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
    public class TorqueMappingBusinessAccess : ITorqueMappingBusinessAccess
    {
        private readonly TorqueMappingDataAccess _TorqueMappingDataAccess = new TorqueMappingDataAccess();

        #region public CollectionResult<int> GetAllTorqueMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<TorqueMapping> GetAllTorqueMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<TorqueMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<TorqueMapping>()
            };

            try
            {
                responseData = _TorqueMappingDataAccess.GetAllTorqueMapping(Connectionstring, BaseUrl);

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
        public CollectionResult<TorqueMapping> GetAllTorqueMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<TorqueMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<TorqueMapping>()
            };

            try
            {
                responseData = _TorqueMappingDataAccess.GetAllTorqueMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);

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

        #region public Result<TorqueMapping> GetByTorqueMappingId(int Id, string Connectionstring) 
        public Result<TorqueMapping> GetByTorqueMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<TorqueMapping>
            {
                Status = true,
                Message = default(string),
                Data = new TorqueMapping()

            };

            try
            {
                responseData = _TorqueMappingDataAccess.GetByTorqueMappingId(Id, Connectionstring, BaseUrl);

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

        #region public Result<int> AddorUpdateTorqueMapping(TorqueMapping values,string Connectionstring) 
        public Result<int> AddorUpdateTorqueMapping(TorqueMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _TorqueMappingDataAccess.AddorUpdateTorqueMapping(values, Connectionstring);

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

        #region Result<int> DeleteTorqueMapping(TorqueMapping values, string Connectionstring);
        public Result<int> DeleteTorqueMapping(TorqueMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _TorqueMappingDataAccess.DeleteTorqueMapping(values, Connectionstring);

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