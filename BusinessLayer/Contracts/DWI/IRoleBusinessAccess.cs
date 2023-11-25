using BusinessModels;
using BusinessModels.COM;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IRoleBusinessAccess
    {
        public CollectionResult<Role> GetAllRoleDetails(int pageIndex, int pageSize, string search, string Connectionstring);
        public Result<Role> GetByRoleId(int RoleId, string Connectionstring);
        public Result<UserPermissions> GetByRoleIdAccess(int Id, string Connectionstring);
        public Result<int> AddorUpdateByRole(UserPermissions values ,string Connectionstring);
        public Result<int> UserModulePermission(int RoleId, UserPermissions value, UserModulePermission values, string Connectionstring);
        public Result<int> DeleteRoleById(Role values, string Connectionstring);

    }
}
