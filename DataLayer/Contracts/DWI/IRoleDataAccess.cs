using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface IRoleDataAccess
    {
        CollectionResult<Role> GetAllRoleDetails(int pageIndex, int pageSize, string search, string Connectionstring);

        Result<Role> GetByRoleId(int RoleId, string Connectionstring);
        Result<UserPermissions> GetByRoleIdAccess(int Id, string Connectionstring);
        Result<int> AddorUpdateByRole(UserPermissions values, string Connectionstring);
        Result<int> UserModulePermission(int RoleId, UserPermissions value, UserModulePermission values, string Connectionstring);
        Result<int> DeleteRoleById(Role values, string Connectionstring);
    }
}
