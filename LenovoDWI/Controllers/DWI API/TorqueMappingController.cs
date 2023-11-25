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

namespace DWI_Lenovo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class TorqueMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITorqueMappingBusinessAccess _TorqueMappingBusinessAccess;
        private readonly IHostingEnvironment _hostingEnvironment;

        public TorqueMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _TorqueMappingBusinessAccess = new TorqueMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult GetAllTorqueMapping()
        [HttpGet]
        [Route("GetAllTorqueMapping")]
        public IActionResult GetAllTorqueMapping()
        {
            var responseData = new CollectionResult<TorqueMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<TorqueMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _TorqueMappingBusinessAccess.GetAllTorqueMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetAllTorqueMappingDetails(int pageIndex, int pageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllTorqueMappingDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<TorqueMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<TorqueMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _TorqueMappingBusinessAccess.GetAllTorqueMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByTorqueMappingId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByTorqueMappingId(int Id)
        {
            var responseData = new Result<TorqueMapping>
            {
                Status = true,
                Message = default(string),
                Data = new TorqueMapping()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    responseData = _TorqueMappingBusinessAccess.GetByTorqueMappingId(Id, Connectionstring, BaseUrl);
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

        #region public IActionResult AddorUpdateTorqueMappingDetails([FromBody]TorqueMapping values)
        [HttpPost]
        [Route("AddorUpdateTorqueMapping")]
        public IActionResult AddorUpdateTorqueMapping([FromForm] TorqueMapping values) 
        {
            try
            {
                TorqueMapping inputRequest = new TorqueMapping();
                if (values.TorquePicFile != null)
                {
                    string uniqueName = values.TorquePicFile.FileName;
                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "TorquePicture");
                    // If directory does not exist, don't even try   
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, uniqueName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.TorquePicFile.CopyTo(stream);
                    }
                    values.TorquePic = uniqueName;
                }

                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> TorqueMappingInsertedDetails = _TorqueMappingBusinessAccess.AddorUpdateTorqueMapping(values, Connectionstring);

                return new JsonResult(TorqueMappingInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteTorqueMapping(int Id, int ModifiedBy)
        [HttpDelete]
        [Route("DeleteTorqueMapping")]
        public IActionResult DeleteTorqueMapping(int Id, int ModifiedBy)
        {
            try
            {
                TorqueMapping values = new TorqueMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _TorqueMappingBusinessAccess.DeleteTorqueMapping(values, Connectionstring);
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
