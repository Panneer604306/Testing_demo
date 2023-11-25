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
    public class CPULabelMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICPULabelMappingBusinessAccess _cpulabelmappingBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;


        public CPULabelMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _cpulabelmappingBusiness = new CPULabelMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult getCPULabelMapping()
        [HttpGet]
        [Route("GetAllCPULabelMapping")]
        public IActionResult GetAllCPULabelMapping()
        {
            var responseData = new CollectionResult<CPULabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<CPULabelMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _cpulabelmappingBusiness.GetAllCPULabelMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetAllCPULabelMappingDetails(int pageIndex, int pageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllCPULabelMappingDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<CPULabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<CPULabelMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _cpulabelmappingBusiness.GetAllCPULabelMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByCPULabelMappingId(int CPULabelMappingId)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByCPULabelMappingId(int CPULabelMappingId)
        {
            var responseData = new Result<CPULabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new CPULabelMapping()

            };
            try
            {
                if (CPULabelMappingId > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    responseData = _cpulabelmappingBusiness.GetByCPULabelMappingId(CPULabelMappingId, Connectionstring, BaseUrl);
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

        #region public IActionResult AddorUpdateCPULabelMapping([FromBody]CPULabelMapping values)
        [HttpPost]
        [Route("AddorUpdateCPULabelMapping")]
        public IActionResult AddorUpdateCPULabelMapping([FromForm] CPULabelMapping values)
        {
            try
            {
                CPULabelMapping inputRequest = new CPULabelMapping();
                if (values.CPULabelPicFile != null)
                {
                    string uniqueName = values.CPULabelPicFile.FileName;
                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "CPULabelPicture");
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, uniqueName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.CPULabelPicFile.CopyTo(stream);
                    }
                    values.CPULabelPic = uniqueName;
                }
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> CPULabelMappingInsertedDetails = _cpulabelmappingBusiness.AddorUpdateCPULabelMapping(values, Connectionstring);

                return new JsonResult(CPULabelMappingInsertedDetails);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
        #endregion

        #region public IActionResult DeleteCPULabelMapping(int CPULabelMappingId)
        [HttpDelete]
        [Route("DeleteCPULabelMapping")]
        public IActionResult DeleteCPULabelMapping(int Id, int ModifiedBy)
        {
            try
            {
                CPULabelMapping values = new CPULabelMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _cpulabelmappingBusiness.DeleteCPULabelMapping(values, Connectionstring);
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
