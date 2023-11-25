
using BusinessLayer.Contracts;
using BusinessModels;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace BusinessLayer
{
    public class PartBusinessAccess : IPartBusinessAccess
    {
        private readonly PartDataAccess _partDataAccess = new PartDataAccess();

        public PartBusinessAccess()
        {
        }

        #region public CollectionResult<int> GetAllPart(string Connectionstring, string BaseUrl) 
        public CollectionResult<Part> GetAllPart(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<Part>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<Part>()
            };

            try
            {
                responseData = _partDataAccess.GetAllPart(Connectionstring, BaseUrl);

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
        public CollectionResult<Part> GetAllPartDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<Part>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<Part>()
            };

            try
            {
                responseData = _partDataAccess.GetAllPartDetails(pageIndex, pageSize, search, Connectionstring);

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

        #region public Result<Part> GetByPartId(int Id, string Connectionstring) 
        public Result<Part> GetByPartId(int Id, string Connectionstring)
        {
            var responseData = new Result<Part>
            {
                Status = true,
                Message = default(string),
                Data = new Part()

            };

            try
            {
                responseData = _partDataAccess.GetByPartId(Id, Connectionstring);

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

        #region public Result<int> AddorUpdatePart(Part values,string Connectionstring) 
        public Result<int> AddorUpdatePart(Part values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _partDataAccess.AddorUpdatePart(values, Connectionstring);

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

        #region public Result<int> DeletePart(Part values, string Connectionstring) 
        public Result<int> DeletePart(Part values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _partDataAccess.DeletePart(values, Connectionstring);

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
