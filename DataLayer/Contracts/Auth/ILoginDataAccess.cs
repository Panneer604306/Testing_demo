using BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts
{
    public interface ILoginDataAccess
    {
        /// <summary>
        /// To get the User login details
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="Connectionstring"></param>
        /// <returns></returns>
        Result<Login> GetLoginDetails(string username, string password, string Connectionstring);

        /// <summary>
        /// To Add the JWT token for loggedin user
        /// </summary>
        /// <param name="Authtoken"></param>
        /// <param name="username"></param>
        /// <param name="Connectionstring"></param>
        /// <returns></returns>
        Result<int> UpdateUserAuthtoken(string Authtoken, string username, string Connectionstring);

        /// <summary>
        /// To Add the JWT token for loggedin user
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="Connectionstring"></param>
        /// <returns></returns>
        Result<Login> ForgetPassword(string EmailId, string Connectionstring);



    }
}
