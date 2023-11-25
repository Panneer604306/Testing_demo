using BusinessLayer.Contracts.DWI;
using BusinessModels;
using BusinessModels.DWI;
using DataLayer.DWI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace BusinessLayer.DWI
{
    public class SolutionTypeBusinessAccess : ISolutionTypeBusinessAccess
    {
        private readonly SolutionTypeDataAccess _SolutionTypeDataAccess = new SolutionTypeDataAccess();

        #region public CollectionResult<int> GetAllSolutionType(string Connectionstring, string BaseUrl) 
        public CollectionResult<SolutionType> GetAllSolutionType(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<SolutionType>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SolutionType>()
            };

            try
            {
                responseData = _SolutionTypeDataAccess.GetAllSolutionType(Connectionstring, BaseUrl);

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

        #region public CollectionResult<int> GetAllSolutionTypeDetails(int pageIndex, int pageSize, string search, string Connectionstring) 
        public CollectionResult<SolutionType> GetAllSolutionTypeDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<SolutionType>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SolutionType>()
            };

            try
            {
                responseData = _SolutionTypeDataAccess.GetAllSolutionTypeDetails(pageIndex, pageSize, search, Connectionstring);

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

        #region public Result<SolutionType> GetBySolutionTypeId(int Id, string Connectionstring) 
        public Result<SolutionType> GetBySolutionTypeId(int Id, string Connectionstring)
        {
            var responseData = new Result<SolutionType>
            {
                Status = true,
                Message = default(string),
                Data = new SolutionType()

            };

            try
            {
                responseData = _SolutionTypeDataAccess.GetBySolutionTypeId(Id, Connectionstring);

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

        #region public Result<int> AddorUpdateSolutionType(SolutionType values,string Connectionstring) 
        public Result<int> AddorUpdateSolutionType(SolutionType values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _SolutionTypeDataAccess.AddorUpdateSolutionType(values, Connectionstring);

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

        #region public Result<int> DeleteSolutionType(SolutionType values, string Connectionstring) 
        public Result<int> DeleteSolutionType(SolutionType values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _SolutionTypeDataAccess.DeleteSolutionType(values, Connectionstring);

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
