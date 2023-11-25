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
    public class SafetyMappingBusinessAccess : ISafetyMappingBusinessAccess
    {
        private readonly SafetyDataAccess _safetyDataAccess = new SafetyDataAccess();
        public SafetyMappingBusinessAccess()
        {
        }

        #region public CollectionResult<int> GetAllSafetyMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<SafetyMapping> GetAllSafetyMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<SafetyMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SafetyMapping>()
            };

            try
            {
                responseData = _safetyDataAccess.GetAllSafetyMapping(Connectionstring, BaseUrl);

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

        #region public Result<int> GetSafetyInsertedDetails(Safety values,string Connectionstring)
        /// <summary>
        /// To insert the Safety data in DB and to get the inserted status
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Result<int> GetSafetyInsertedDetails(Safety values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _safetyDataAccess.GetSafetyInsertedDetails(values, Connectionstring);

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

        #region public Result<int> GetSafetyDetails(Safety values,string Connectionstring) 
        public Result<int> AddorUpdateSafetyDetails(SafetyMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _safetyDataAccess.AddorUpdateSafetyDetails(values, Connectionstring);

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

        #region public CollectionResult<int> GetAllPartDetails(string Connectionstring) 
        public CollectionResult<SafetyMapping> GetAllSafetyDetails(int PageIndex, int PageSize, string search, string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<SafetyMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SafetyMapping>()
            };

            try
            {
                responseData = _safetyDataAccess.GetAllSafetyDetails(PageIndex, PageSize, search, Connectionstring, BaseUrl);

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

        #region public Result<Safety> GetBySafetyId(int SafetyId, string Connectionstring) 
        public Result<SafetyMapping> GetBySafetyId(int Id, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<SafetyMapping>
            {
                Status = true,
                Message = default(string),
                Data = new SafetyMapping()

            };

            try
            {
                responseData = _safetyDataAccess.GetBySafetyId(Id, Connectionstring, BaseUrl);

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

        /*  #region public Result<int> DeleteSafetyDetails(int SafetyId, string Connectionstring) 
          public Result<int> DeleteSafetyDetails(int Id, string Connectionstring)
          {
              var responseData = new Result<int>
              {
                  Status = true,
                  Message = default(string),
                  Data = new int()
              };

              try
              {
                  responseData = _safetyDataAccess.DeleteSafetyDetails(Id, Connectionstring);

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

          #endregion*/

        #region Result<int> DeleteSafetyDetails(SafetyMapping values, string Connectionstring);
        public Result<int> DeleteSafetyDetails(SafetyMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _safetyDataAccess.DeleteSafetyDetails(values, Connectionstring);

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
