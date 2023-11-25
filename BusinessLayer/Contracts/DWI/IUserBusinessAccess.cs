using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IUserBusinessAccess
    {
        CollectionResult<User> GetAllUser(string Connectionstring, string BaseUrl);

        CollectionResult<User> GetAllUserDetails(int pageIndex, int pageSize, string search, string Connectionstring);

        Result<User> GetByUserId(int UserId, string Connectionstring);
       
        Result<int> AddorUpdateUser(User values, string Connectionstring);

        Result<int> DeleteUser(User values, string Connectionstring);


    }
}
