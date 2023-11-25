using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using DataLayer.DWI;
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
    public class GraphicsLabelMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGraphicLabelMappingBusinessAccess _grapiclabelmappingBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;


        public GraphicsLabelMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _grapiclabelmappingBusiness = new GrapicLabelMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult getAllGraphicsLabelMapping()
        [HttpGet]
        [Route("GetAllGraphicsLabelMapping")]
        public IActionResult GetAllGraphicsLabelMapping()
        {
            var responseData = new CollectionResult<GraphicLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GraphicLabelMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _grapiclabelmappingBusiness.GetAllGraphicLabelMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetAllGraphicLabelMappingDetails(int PageIndex, int PageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllGraphicLabelMappingDetails(int PageIndex, int PageSize, string search)
        {
            var responseData = new CollectionResult<GraphicLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GraphicLabelMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _grapiclabelmappingBusiness.GetAllGraphicLabelMappingDetails(PageIndex, PageSize, search, Connectionstring, BaseUrl);
                return new JsonResult(responseData);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByGraphLabelMappingId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByGraphicLabelMappingId(int Id)
        {
            var responseData = new Result<GraphicLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new GraphicLabelMapping()

            };
            try
            {

                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    responseData = _grapiclabelmappingBusiness.GetByGraphicLabelMappingId(Id, Connectionstring, BaseUrl);
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

        #region public IActionResult AddorUpdateGraphLabelMappingDetails([FromBody]CPULabelMapping values)
        [HttpPost]
        [Route("AddorUpdateGraphicLabelMapping")]
        public IActionResult AddorUpdateGraphicLabelMapping([FromForm] GraphicLabelMapping values)
        {
            try
            {
                GraphicLabelMapping inputRequest = new GraphicLabelMapping();
                if (values.GraphicLabelFile != null)
                {
                    string uniqueName = values.GraphicLabelFile.FileName;
                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "GraphicLabelPicture");
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, uniqueName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.GraphicLabelFile.CopyTo(stream);
                    }
                    values.GraphicLabelPic = uniqueName;
                }
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> CPULabelMappingInsertedDetails = _grapiclabelmappingBusiness.AddorUpdateGraphicLabelMapping(values, Connectionstring);
                return new JsonResult(CPULabelMappingInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteGraphicLabelMapping(int GraphicLabelId)
        [HttpDelete]
        [Route("DeleteGraphicLabelMapping")]
        public IActionResult DeleteGraphicLabelMapping(int Id, int ModifiedBy)
        {
            try
            {
                GraphicLabelMapping values = new GraphicLabelMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _grapiclabelmappingBusiness.DeleteGraphicLabelMapping(values, Connectionstring);
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
