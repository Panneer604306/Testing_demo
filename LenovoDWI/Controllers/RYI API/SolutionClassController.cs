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
    public class SolutionClassController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISolutionClassBusinessAccess _SolutionClassBusiness;

        public SolutionClassController(IConfiguration configuration)
        {
            _configuration = configuration;
            _SolutionClassBusiness = new SolutionClassBusinessAccess();
        }

        #region public IActionResult GetAllSolutionClass()
        [HttpGet]
        [Route("GetAllSolutionClass")]
        public IActionResult GetAllSolutionClass()
        {
            var responseData = new CollectionResult<SolutionClass>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SolutionClass>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _SolutionClassBusiness.GetAllSolutionClass(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult getSolutionClassDetails()
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetSolutionClassDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<SolutionClass>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SolutionClass>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _SolutionClassBusiness.GetAllSolutionClassDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetBySolutionClassId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetBySolutionClassId(int Id)
        {
            var responseData = new Result<SolutionClass>
            {
                Status = true,
                Message = default(string),
                Data = new SolutionClass()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _SolutionClassBusiness.GetBySolutionClassId(Id, Connectionstring);
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

        #region public IActionResult AddorUpdateSolutionClass([FromBody]SolutionClass values)
        [HttpPost]
        [Route("AddorUpdateSolutionClass")]
        public IActionResult AddorUpdateSolutionClass([FromBody] SolutionClass values)
        {

            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> SolutionClassInsertedDetails = _SolutionClassBusiness.AddorUpdateSolutionClass(values, Connectionstring);
                return new JsonResult(SolutionClassInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteSolutionClassRecord(int SolutionClassId)
        [HttpDelete]
        [Route("DeleteSolutionClass")]
        public IActionResult DeleteSolutionClass(int Id, int ModifiedBy)
        {
            try
            {
                SolutionClass values = new SolutionClass();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _SolutionClassBusiness.DeleteSolutionClass(values, Connectionstring);
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