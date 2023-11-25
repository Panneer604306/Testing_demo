using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.COM;
using BusinessModels.DWI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DWI_Application.Controllers.DWI_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class RoleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRoleBusinessAccess _roleBusiness;

        public RoleController(IConfiguration configuration)
        {
            _configuration = configuration;
            _roleBusiness = new RoleBusinessAccess();
        }

        #region public IActionResult GetAllRolesDetails(int pageIndex, int pageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllRoleDetails(int pageIndex, int pageSize, string search)
        {
            var result = new CollectionResult<Role>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<Role>()
            };


            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                result = _roleBusiness.GetAllRoleDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByRoleId(int RoleId)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByRoleId(int RoleId)
        {
            var responseData = new Result<Role>
            {
                Status = true,
                Message = default(string),
                Data = new Role()

            };
            try
            {
                if (RoleId > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _roleBusiness.GetByRoleId(RoleId, Connectionstring);
                    return new JsonResult(responseData);
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Invalid parameter value detected.!!!", Data = 0 });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByRoleIdAccess(string RoleName)
        [HttpGet]
        [Route("GetByRoleIdAccess")]
        public IActionResult GetByRoleIdAccess(int Id)
        {
            var responseData = new Result<UserPermissions>
            {
                Status = true,
                Message = default(string),
                Data = new UserPermissions()

            };
            try
            {
                if (Id != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _roleBusiness.GetByRoleIdAccess(Id, Connectionstring);
                    return new JsonResult(responseData);
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Invalid parameter value detected.!!!", Data = 0 });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  public IActionResult Rolladdded([FromBody] RollControl values)
        [HttpPost]
        [Route("UserModulePermission")]
        public IActionResult UserModulePermission(UserPermissions values)
        {

            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };


            try

            {
                if (values.Role != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _roleBusiness.AddorUpdateByRole(values, Connectionstring);
                    if(responseData.Status)
                    {
                        foreach (var item in values.ObjLstUserModule)
                        {
                            result = _roleBusiness.UserModulePermission(responseData.Data, values, item, Connectionstring);
                        }
                    }
                    
                }
                return new JsonResult(responseData);
            }

            catch (Exception ex)
            {
                throw ex;
            }



        }
        #endregion

        #region public IActionResult DeleteRoleById(int RoleId, int ModifiedBy)
        [HttpDelete]
        [Route("DeleteRoleById")]
        public IActionResult DeleteRoleById(int RoleId, int ModifiedBy)
        {
            try
            {
                Role values = new Role();
                values.Id = RoleId;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _roleBusiness.DeleteRoleById(values, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
