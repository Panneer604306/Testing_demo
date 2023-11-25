using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DWI_Application.Controllers.DWI_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class StageMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStageMappingBusinessAccess _StageMappingBusinessAccess;
        private readonly IHostingEnvironment _hostingEnvironment;

        public StageMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _StageMappingBusinessAccess = new StageMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult getStageMapping()
        [HttpGet]
        [Route("GetAllStageMapping")]
        public IActionResult GetAllStageMapping()
        {
            var responseData = new CollectionResult<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<StageMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _StageMappingBusinessAccess.GetAllStageMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetAllStageMappingDetails(int pageIndex, int pageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllStageMappingDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<StageMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _StageMappingBusinessAccess.GetAllStageMappingDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByStageMappingId(string StageMappingId)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByStageMappingId(int Id)
        {
            var responseData = new Result<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new StageMapping()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _StageMappingBusinessAccess.GetByStageMappingId(Id, Connectionstring);
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

        #region public IActionResult AddorUpdateStageMappingDetails([FromBody]StageMapping values)
        [HttpPost]
        [Route("AddorUpdateStageMapping")]
        public IActionResult AddorUpdateStageMapping([FromBody] StageMapping values)
        {
            try
            {
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> StageMappingInsertedDetails = _StageMappingBusinessAccess.AddorUpdateStageMapping(values, Connectionstring);
                return new JsonResult(StageMappingInsertedDetails);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteStageMapping(string Stage, int ModifiedBy)
        [HttpDelete]
        [Route("DeleteStageMapping")]
        public IActionResult DeleteStageMapping(int Id, int ModifiedBy)
        {
            try
            {
                StageMapping values = new StageMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _StageMappingBusinessAccess.DeleteStageMapping(values, Connectionstring);
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
