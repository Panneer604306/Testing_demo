using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using BusinessLayer;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace DWI_Application.Controllers.DWI_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ProductMappingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IProductMappingBusinessAccess _productmappingBusinessAccess;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductMappingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _productmappingBusinessAccess = new ProductMappingBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult getProductMapping()
        [HttpGet]
        [Route("GetAllProductMapping")]
        public IActionResult GetAllProductMapping()
        {
            var responseData = new CollectionResult<ProductMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProductMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _productmappingBusinessAccess.GetAllProductMapping(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetAllProductMappingDetails(int pageIndex, int pageSize, string search)
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllProductMappingDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<ProductMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProductMapping>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _productmappingBusinessAccess.GetAllProductMappingDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByProductMappingId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByProductMappingId(int Id)
        {
            var responseData = new Result<ProductMapping>
            {
                Status = true,
                Message = default(string),
                Data = new ProductMapping()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _productmappingBusinessAccess.GetByProductMappingId(Id, Connectionstring);
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



        #region public IActionResult AddorUpdateProductMappingDetails([FromBody]ProductMapping values)
        [HttpPost]
        [Route("AddorUpdateProductMapping")]
        public IActionResult AddorUpdateProductMapping([FromBody] ProductMapping values)
        {
            try
            {
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> ProductMappingInsertedDetails = _productmappingBusinessAccess.AddorUpdateProductMapping(values, Connectionstring);

                return new JsonResult(ProductMappingInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteProductMapping(string MTId, int ModifiedBy)
        [HttpDelete]
        [Route("DeleteProductMapping")]
        public IActionResult DeleteProductMapping(int Id, int ModifiedBy)
        {
            try
            {
                ProductMapping values = new ProductMapping();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _productmappingBusinessAccess.DeleteProductMapping(values, Connectionstring);
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
