using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    public class OSLabelMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOSLabelMappingBusinessAccess _oslabelmappingBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;

        public OSLabelMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _oslabelmappingBusiness = new OSLabelMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult getOSLabelMapping()
        [HttpGet]
        [Route("GetAllOSLabelMapping")]
        public IActionResult GetAllOSLabelMapping()
        {
            var responseData = new CollectionResult<OSLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<OSLabelMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _oslabelmappingBusiness.GetAllOSLabelMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetAllOSLabelMappingDetails(int pageIndex, int pageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllOSLabelMappingDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<OSLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<OSLabelMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _oslabelmappingBusiness.GetAllOSLabelMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByOSLabelMappingId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByOSLabelMappingId(int Id)
        {
            var responseData = new Result<OSLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new OSLabelMapping()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    responseData = _oslabelmappingBusiness.GetByOSLabelMappingId(Id, Connectionstring, BaseUrl);
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

        #region public IActionResult AddorUpdateOSLabelMappingDetails([FromBody]OSLabelMapping values)
        [HttpPost]
        [Route("AddorUpdateOSLabelMapping")]
        public IActionResult AddorUpdateOSLabelMapping([FromForm] OSLabelMapping values)
        {
            try
            {
                OSLabelMapping inputRequest = new OSLabelMapping();
                if (values.OSLabelPicFile != null)
                {
                    string uniqueName = values.OSLabelPicFile.FileName;
                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "OSLabelPicture");
                    // If directory does not exist, don't even try   
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, uniqueName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.OSLabelPicFile.CopyTo(stream);
                    }
                    values.OSLabelPic = uniqueName;
                }
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> OSLabelMappingInsertedDetails = _oslabelmappingBusiness.AddorUpdateOSLabelMapping(values, Connectionstring);

                return new JsonResult(OSLabelMappingInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteOSLabelMapping(int Id, int ModifiedBy)
        [HttpDelete]
        [Route("DeleteOSLabelMapping")]
        public IActionResult DeleteOSLabelMapping(int Id, int ModifiedBy)
        {
            try
            {
                OSLabelMapping values = new OSLabelMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _oslabelmappingBusiness.DeleteOSLabelMapping(values, Connectionstring);
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
