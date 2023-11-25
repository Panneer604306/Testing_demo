using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class PartPicMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPartPicMappingBusinessAccess _PartPicMappingBusinessAccess;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PartPicMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _PartPicMappingBusinessAccess = new PartPicMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult getAllPartPicMapping()
        [HttpGet]
        [Route("GetAllPartPicMapping")]
        public IActionResult GetAllPartPicMapping()
        {
            var responseData = new CollectionResult<PartPicMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<PartPicMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _PartPicMappingBusinessAccess.GetAllPartPicMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetAllPartPicMappingDetails(int pageIndex, int pageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllPartPicMappingDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<PartPicMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<PartPicMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _PartPicMappingBusinessAccess.GetAllPartPicMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByPartPicMappingId(Int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByPartPicMappingId(int Id)
        {
            var responseData = new Result<PartPicMapping>
            {
                Status = true,
                Message = default(string),
                Data = new PartPicMapping()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    responseData = _PartPicMappingBusinessAccess.GetByPartPicMappingId(Id, Connectionstring, BaseUrl);
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

        #region public IActionResult AddorUpdatePartPicMappingDetails([FromBody]PartPicMapping values)
        [HttpPost]
        [Route("AddorUpdatePartPicMapping")]
        public IActionResult AddorUpdatePartPicMapping([FromForm] PartPicMapping values)
        {
            try
            {
                PartPicMapping inputRequest = new PartPicMapping();
                if (values.PartPicFile != null)
                {
                    string uniqueName = values.PartPicFile.FileName;
                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "PartPicture");
                    // If directory does not exist, don't even try   
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, uniqueName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.PartPicFile.CopyTo(stream);
                    }
                    values.PartPic = uniqueName;
                }
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> PartPicMappingInsertedDetails = _PartPicMappingBusinessAccess.AddorUpdatePartPicMapping(values, Connectionstring);

                return new JsonResult(PartPicMappingInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeletePartPicMapping(int Id, int ModifiedBy)
        [HttpDelete]
        [Route("DeletePartPicMapping")]
        public IActionResult DeletePartPicMapping(int Id, int ModifiedBy)
        {
            try
            {
                PartPicMapping values = new PartPicMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _PartPicMappingBusinessAccess.DeletePartPicMapping(values, Connectionstring);
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
