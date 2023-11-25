using BusinessLayer;
using BusinessLayer.Contracts;
using BusinessModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.ObjectModel;

namespace DWI_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class PartController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPartBusinessAccess _partBusiness;

        public PartController(IConfiguration configuration)
        {
            _configuration = configuration;
            _partBusiness = new PartBusinessAccess();
        }

        #region public IActionResult GetAllPart()
        [HttpGet]
        [Route("GetAllPart")]
        public IActionResult GetAllPart()
        {
            var responseData = new CollectionResult<Part>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<Part>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _partBusiness.GetAllPart(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult getPartDetails()
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetPartDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<Part>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<Part>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _partBusiness.GetAllPartDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByPartId(int partId)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByPartId(int Id)
        {
            var responseData = new Result<Part>
            {
                Status = true,
                Message = default(string),
                Data = new Part()

            };
            try
            {
                if(Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _partBusiness.GetByPartId(Id, Connectionstring);
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

        #region public IActionResult AddorUpdatePart([FromBody]Part values)
        [HttpPost]
        [Route("AddorUpdatePart")]
        public IActionResult AddorUpdatePart([FromBody]Part values)
        {
        
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> PartInsertedDetails = _partBusiness.AddorUpdatePart(values, Connectionstring);
                return new JsonResult(PartInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeletePartRecord(int partId)
        [HttpDelete]
        [Route("DeletePart")]
        public IActionResult DeletePart(int Id, int ModifiedBy)
        {             
            try
            {
                Part values = new Part();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _partBusiness.DeletePart(values, Connectionstring);
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