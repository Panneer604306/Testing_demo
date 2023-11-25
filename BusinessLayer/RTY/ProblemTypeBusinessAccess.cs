using BusinessLayer.Contracts.DWI;
using BusinessModels;
using BusinessModels.DWI;
using DataLayer.Contracts.DWI;
using DataLayer.DWI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace BusinessLayer.DWI
{
    public class ProblemTypeBusinessAccess : IProblemTypeBusinessAccess
    {
        private readonly ProblemTypeDataAccess _ProblemTypeDataAccess = new ProblemTypeDataAccess();

        #region public CollectionResult<int> GetAllProblemType(string Connectionstring, string BaseUrl) 
        public CollectionResult<ProblemType> GetAllProblemType(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<ProblemType>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProblemType>()
            };

            try
            {
                responseData = _ProblemTypeDataAccess.GetAllProblemType(Connectionstring, BaseUrl);

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

        #region public CollectionResult<int> GetAllProblemTypeDetails(int pageIndex, int pageSize, string search, string Connectionstring) 
        public CollectionResult<ProblemType> GetAllProblemTypeDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<ProblemType>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProblemType>()
            };

            try
            {
                responseData = _ProblemTypeDataAccess.GetAllProblemTypeDetails(pageIndex, pageSize, search, Connectionstring);

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

        #region public Result<ProblemType> GetByProblemTypeId(int Id, string Connectionstring) 
        public Result<ProblemType> GetByProblemTypeId(int Id, string Connectionstring)
        {
            var responseData = new Result<ProblemType>
            {
                Status = true,
                Message = default(string),
                Data = new ProblemType()

            };

            try
            {
                responseData = _ProblemTypeDataAccess.GetByProblemTypeId(Id, Connectionstring);

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

        #region public Result<int> AddorUpdateProblemType(ProblemType values,string Connectionstring) 
        public Result<int> AddorUpdateProblemType(ProblemType values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _ProblemTypeDataAccess.AddorUpdateProblemType(values, Connectionstring);

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

        #region public Result<int> DeleteProblemType(ProblemType values, string Connectionstring) 
        public Result<int> DeleteProblemType(ProblemType values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _ProblemTypeDataAccess.DeleteProblemType(values, Connectionstring);

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
