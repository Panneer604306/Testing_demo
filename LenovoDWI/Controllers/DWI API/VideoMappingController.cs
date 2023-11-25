using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using DWI_Application.MailTemplates;
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
    public class VideoMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IVideoMappingBusinessAccess _VideomappingBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;

        public VideoMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _VideomappingBusiness = new VideoMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult GetAllVideoMapping()
        [HttpGet]
        [Route("GetAllVideoMapping")]
        public IActionResult GetAllVideoMapping()
        {
            var responseData = new CollectionResult<VideoMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<VideoMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _VideomappingBusiness.GetAllVideoMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetAllVideoMappingDetails(int pageIndex, int pageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllVideoMappingDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<VideoMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<VideoMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _VideomappingBusiness.GetAllVideoMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByVideoMappingId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByVideoMappingId(int Id)
        {
            var responseData = new Result<VideoMapping>
            {
                Status = true,
                Message = default(string),
                Data = new VideoMapping()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    responseData = _VideomappingBusiness.GetByVideoMappingId(Id, Connectionstring, BaseUrl);
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

        #region public IActionResult AddorUpdateVideoMapping([FromBody]VideoMapping values)
        //[DisableRequestSizeLimit]
        [HttpPost]
        [Route("AddorUpdateVideoMapping")]
        public IActionResult AddorUpdateVideoMapping([FromForm] VideoMapping values)
        {
            try
            {
                VideoMapping inputRequest = new VideoMapping();
                var file = values.VideoFile;

                if (file != null)
                {
                    string uniqueName = file.FileName;
                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Videos");
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, uniqueName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.VideoFile.CopyTo(stream);
                    }
                    values.Video = file.FileName;
                }
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> ResultVideoMappingDetails = _VideomappingBusiness.AddorUpdateVideoMapping(values, Connectionstring);
                return new JsonResult(ResultVideoMappingDetails);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteVideMappingRecord(int VideoMappingMT)
        [HttpDelete]
        [Route("DeleteVideMapping")]
        public IActionResult DeleteVideMappingRecord(int Id, int ModifiedBy)
        {
            try
            {
                VideoMapping values = new VideoMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _VideomappingBusiness.DeleteVideoMapping(values, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        //[HttpPost]
        //[Route("UploadFile")]
        //public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        //{
        //    try
        //    {
                

        //        return Ok("File(s) uploaded successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error uploading file: {ex.Message}");
        //    }
        //}



    }
}
