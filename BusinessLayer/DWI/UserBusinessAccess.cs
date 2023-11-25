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
    public class UserBusinessAccess : IUserBusinessAccess
    {
        private readonly UserDataAccess _userDataAccess = new UserDataAccess();

        public UserBusinessAccess()
        {
        }

        #region public CollectionResult<int> GetAllUser(string Connectionstring, string BaseUrl) 
        public CollectionResult<User> GetAllUser(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<User>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<User>()
            };

            try
            {
                responseData = _userDataAccess.GetAllUser(Connectionstring, BaseUrl);

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

        #region public CollectionResult<int> GetAllUserDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        public CollectionResult<User> GetAllUserDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<User>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<User>()
            };

            try
            {
                responseData = _userDataAccess.GetAllUserDetails(pageIndex, pageSize, search, Connectionstring);

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

        #region public Result<User> GetByUserId(int Id, string Connectionstring)
        public Result<User> GetByUserId(int Id, string Connectionstring)
        {
            var responseData = new Result<User>
            {
                Status = true,
                Message = default(string),
                Data = new User()

            };

            try
            {
                responseData = _userDataAccess.GetByUserId(Id, Connectionstring);

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

        #region public Result<int> AddorUpdateUser(User values,string Connectionstring) 
        public Result<int> AddorUpdateUser(User values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _userDataAccess.AddorUpdateUser(values, Connectionstring);

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

        #region public Result<int> DeleteUser(User values, string Connectionstring) 
        public Result<int> DeleteUser(User values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _userDataAccess.DeleteUser(values, Connectionstring);

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
