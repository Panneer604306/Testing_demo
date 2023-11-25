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
    public class SolutionClassBusinessAccess : ISolutionClassBusinessAccess
    {
        private readonly SolutionClassDataAccess _SolutionClassDataAccess = new SolutionClassDataAccess();

        #region public CollectionResult<int> GetAllSolutionClass(string Connectionstring, string BaseUrl) 
        public CollectionResult<SolutionClass> GetAllSolutionClass(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<SolutionClass>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SolutionClass>()
            };

            try
            {
                responseData = _SolutionClassDataAccess.GetAllSolutionClass(Connectionstring, BaseUrl);

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

        #region public CollectionResult<int> GetAllSolutionClassDetails(int pageIndex, int pageSize, string search, string Connectionstring) 
        public CollectionResult<SolutionClass> GetAllSolutionClassDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<SolutionClass>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SolutionClass>()
            };

            try
            {
                responseData = _SolutionClassDataAccess.GetAllSolutionClassDetails(pageIndex, pageSize, search, Connectionstring);

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

        #region public Result<SolutionClass> GetBySolutionClassId(int Id, string Connectionstring) 
        public Result<SolutionClass> GetBySolutionClassId(int Id, string Connectionstring)
        {
            var responseData = new Result<SolutionClass>
            {
                Status = true,
                Message = default(string),
                Data = new SolutionClass()

            };

            try
            {
                responseData = _SolutionClassDataAccess.GetBySolutionClassId(Id, Connectionstring);

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

        #region public Result<int> AddorUpdateSolutionClass(SolutionClass values,string Connectionstring) 
        public Result<int> AddorUpdateSolutionClass(SolutionClass values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _SolutionClassDataAccess.AddorUpdateSolutionClass(values, Connectionstring);

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

        #region public Result<int> DeleteSolutionClass(SolutionClass values, string Connectionstring) 
        public Result<int> DeleteSolutionClass(SolutionClass values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _SolutionClassDataAccess.DeleteSolutionClass(values, Connectionstring);

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
