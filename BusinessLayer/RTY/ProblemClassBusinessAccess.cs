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
    public class ProblemClassBusinessAccess : IProblemClassBusinessAccess
    {
        private readonly ProblemClassDataAccess _ProblemClassDataAccess = new ProblemClassDataAccess();

        #region public CollectionResult<int> GetAllProblemClass(string Connectionstring, string BaseUrl) 
        public CollectionResult<ProblemClass> GetAllProblemClass(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<ProblemClass>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProblemClass>()
            };

            try
            {
                responseData = _ProblemClassDataAccess.GetAllProblemClass(Connectionstring, BaseUrl);

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

        #region public CollectionResult<int> GetAllProblemClassDetails(int pageIndex, int pageSize, string search, string Connectionstring) 
        public CollectionResult<ProblemClass> GetAllProblemClassDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<ProblemClass>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProblemClass>()
            };

            try
            {
                responseData = _ProblemClassDataAccess.GetAllProblemClassDetails(pageIndex, pageSize, search, Connectionstring);

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

        #region public Result<ProblemClass> GetByProblemClassId(int Id, string Connectionstring) 
        public Result<ProblemClass> GetByProblemClassId(int Id, string Connectionstring)
        {
            var responseData = new Result<ProblemClass>
            {
                Status = true,
                Message = default(string),
                Data = new ProblemClass()

            };

            try
            {
                responseData = _ProblemClassDataAccess.GetByProblemClassId(Id, Connectionstring);

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

        #region public Result<int> AddorUpdateProblemClass(ProblemClass values,string Connectionstring) 
        public Result<int> AddorUpdateProblemClass(ProblemClass values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _ProblemClassDataAccess.AddorUpdateProblemClass(values, Connectionstring);

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

        #region public Result<int> DeleteProblemClass(ProblemClass values, string Connectionstring) 
        public Result<int> DeleteProblemClass(ProblemClass values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _ProblemClassDataAccess.DeleteProblemClass(values, Connectionstring);

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
