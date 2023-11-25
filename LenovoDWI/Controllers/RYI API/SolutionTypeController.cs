using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DWI_Application.Controllers.DWI_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class SolutionTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISolutionTypeBusinessAccess _SolutionTypeBusiness;

        public SolutionTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _SolutionTypeBusiness = new SolutionTypeBusinessAccess();
        }

        #region public IActionResult GetAllSolutionType()
        [HttpGet]
        [Route("GetAllSolutionType")]
        public IActionResult GetAllSolutionType()
        {
            var responseData = new CollectionResult<SolutionType>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SolutionType>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _SolutionTypeBusiness.GetAllSolutionType(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult getSolutionTypeDetails()
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetSolutionTypeDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<SolutionType>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SolutionType>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _SolutionTypeBusiness.GetAllSolutionTypeDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetBySolutionTypeId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetBySolutionTypeId(int Id)
        {
            var responseData = new Result<SolutionType>
            {
                Status = true,
                Message = default(string),
                Data = new SolutionType()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _SolutionTypeBusiness.GetBySolutionTypeId(Id, Connectionstring);
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

        #region public IActionResult AddorUpdateSolutionType([FromBody]SolutionType values)
        [HttpPost]
        [Route("AddorUpdateSolutionType")]
        public IActionResult AddorUpdateSolutionType([FromBody] SolutionType values)
        {

            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> SolutionTypeInsertedDetails = _SolutionTypeBusiness.AddorUpdateSolutionType(values, Connectionstring);
                return new JsonResult(SolutionTypeInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteSolutionTypeRecord(int SolutionTypeId)
        [HttpDelete]
        [Route("DeleteSolutionType")]
        public IActionResult DeleteSolutionType(int Id, int ModifiedBy)
        {
            try
            {
                SolutionType values = new SolutionType();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _SolutionTypeBusiness.DeleteSolutionType(values, Connectionstring);
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