using BusinessLayer.Contracts;
using BusinessModels;
using DataLayer;
using DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer
{
    public class LoginBusinessAccess : ILoginBusinessAccess
    {
        private readonly ILoginDataAccess _loginDataAccess = new LoginDataAccess();

        public LoginBusinessAccess()
        {
        }

        #region public Result<Login> GetLoginDetails(string username, string password, string Connectionstring)
        /// <summary>
        /// To get the User login details
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="Connectionstring"></param>
        /// <returns></returns>
        public Result<Login> GetLoginDetails(string username, string password, string Connectionstring)
        {
            var result = new Result<Login>
            {
                Status = true,
                Message = default(string),
                Data = new Login()
            };

            try
            {
                result = _loginDataAccess.GetLoginDetails(username, password, Connectionstring);

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

        #region public Result<int> UpdateUserAuthtoken(string Authtoken, string username,string Connectionstring)
        /// <summary>
        /// To insert the part data in DB and to get the inserted status
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public Result<int> UpdateUserAuthtoken(string Authtoken, string username, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _loginDataAccess.UpdateUserAuthtoken(Authtoken, username, Connectionstring);

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

        #region public Result<Login> ForgetPassword(string EmailId, string Connectionstring)
        public Result<Login> ForgetPassword(string EmailId, string Connectionstring)
        {
            var responseData = new Result<Login>
            {
                Status = true,
                Message = default(string),
                Data = new Login()

            };

            try
            {
                responseData = _loginDataAccess.ForgetPassword(EmailId, Connectionstring);

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
