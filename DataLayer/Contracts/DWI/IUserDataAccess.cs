using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface IUserDataAccess
    {
        CollectionResult<User> GetAllUser(string Connectionstring, string BaseUrl);
        CollectionResult<User> GetAllUserDetails(int pageIndex, int pageSize, string search, string Connectionstring);

        Result<User> GetByUserId(int UserId, string Connectionstring);

        Result<int> AddorUpdateUser(User values, string Connectionstring);

        Result<int> DeleteUser(User values, string Connectionstring);
    }
}
