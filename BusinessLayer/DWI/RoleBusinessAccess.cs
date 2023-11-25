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
    public class RoleBusinessAccess : IRoleBusinessAccess
    {
        private readonly RoleDataAccess _roleDataAccess = new RoleDataAccess();


        #region public CollectionResult<Role> GetAllRoleDetails(string Connectionstring)
        public CollectionResult<Role> GetAllRoleDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var responseData = new CollectionResult<Role>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<Role>()
            };

            try
            {
                responseData = _roleDataAccess.GetAllRoleDetails(pageIndex, pageSize, search, Connectionstring);

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

        #region public Result<Role> GetByRoleId(int RoleId, string Connectionstring)
        public Result<Role> GetByRoleId(int RoleId, string Connectionstring)
        {
            var responseData = new Result<Role>
            {
                Status = true,
                Message = default(string),
                Data = new Role()

            };

            try
            {
                responseData = _roleDataAccess.GetByRoleId(RoleId, Connectionstring);

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

        #region public Result<UserPermissions> GetByRoleIdAccess(int RoleName, string Connectionstring)
        public Result<UserPermissions> GetByRoleIdAccess(int Id, string Connectionstring)
        {
            var responseData = new Result<UserPermissions>
            {
                Status = true,
                Message = default(string),
                Data = new UserPermissions()

            };

            try
            {
                responseData = _roleDataAccess.GetByRoleIdAccess(Id, Connectionstring);

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

        #region  public Result<int> AddorUpdateByRole(UserPermissions values, string Connectionstring)
        public Result<int> AddorUpdateByRole(UserPermissions values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _roleDataAccess.AddorUpdateByRole(values, Connectionstring);

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

        #region public Result<int> Rolladdded(RollControl values, string Connectionstring)
        public Result<int> UserModulePermission(int RoleId, UserPermissions value, UserModulePermission values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _roleDataAccess.UserModulePermission(RoleId, value, values, Connectionstring);

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

        #region public Result<int> DeleteRoleById(Role values, string Connectionstring)
        public Result<int> DeleteRoleById(Role values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _roleDataAccess.DeleteRoleById(values, Connectionstring);

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
