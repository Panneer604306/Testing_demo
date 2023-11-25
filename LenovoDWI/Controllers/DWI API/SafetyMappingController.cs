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
    public class SafetyMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISafetyMappingBusinessAccess _safetyBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;
        public SafetyMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _safetyBusiness = new SafetyMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult getSafetyMapping()
        [HttpGet]
        [Route("GetAllSafetyMapping")]
        public IActionResult GetAllSafetyMapping()
        {
            var responseData = new CollectionResult<SafetyMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SafetyMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _safetyBusiness.GetAllSafetyMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult getSafetyDetails(int PageIndex, int PageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult getSafetyDetails(int PageIndex, int PageSize, string search)
        {
            var responseData = new CollectionResult<SafetyMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SafetyMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _safetyBusiness.GetAllSafetyDetails(PageIndex, PageSize, search, Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetBySafetyId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetBySafetyId(int Id)
        {
            var responseData = new Result<SafetyMapping>
            {
                Status = true,
                Message = default(string),
                Data = new SafetyMapping()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    responseData = _safetyBusiness.GetBySafetyId(Id, Connectionstring, BaseUrl);
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

        #region public IActionResult AddorUpdateSafetyDetails([FromBody]Safety values)
        [HttpPost]
        [Route("AddorUpdateSafetyDetails")]
        public IActionResult AddorUpdateSafetyDetails([FromForm] SafetyMapping values)
        {
            try
            {
                SafetyMapping inputRequest = new SafetyMapping();
                if (values.SafetyPicFile != null)
                {
                    string uniqueName = values.SafetyPicFile.FileName;
                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "SafetyPicture");
                    // If directory does not exist, don't even try   
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, uniqueName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.SafetyPicFile.CopyTo(stream);
                    }
                    values.SafetyPic = uniqueName;
                }
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> SafetyInsertedDetails = _safetyBusiness.AddorUpdateSafetyDetails(values, Connectionstring);

                return new JsonResult(SafetyInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteSafetyDetails(int Id)
        [HttpDelete]
        [Route("DeleteSafetyRecord")]
        public IActionResult DeleteSafetyDetails(int Id, int ModifiedBy)
        {
            try
            {
                SafetyMapping values = new SafetyMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _safetyBusiness.DeleteSafetyDetails(values, Connectionstring);
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
