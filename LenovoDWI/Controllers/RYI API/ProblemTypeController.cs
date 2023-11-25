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
    public class ProblemTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IProblemTypeBusinessAccess _ProblemTypeBusiness;

        public ProblemTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _ProblemTypeBusiness = new ProblemTypeBusinessAccess();
        }
        #region public IActionResult GetAllProblemType()
        [HttpGet]
        [Route("GetAllProblemType")]
        public IActionResult GetAllProblemType()
        {
            var responseData = new CollectionResult<ProblemType>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProblemType>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _ProblemTypeBusiness.GetAllProblemType(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult getProblemTypeDetails()
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetProblemTypeDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<ProblemType>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProblemType>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _ProblemTypeBusiness.GetAllProblemTypeDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByProblemTypeId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByProblemTypeId(int Id)
        {
            var responseData = new Result<ProblemType>
            {
                Status = true,
                Message = default(string),
                Data = new ProblemType()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _ProblemTypeBusiness.GetByProblemTypeId(Id, Connectionstring);
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

        #region public IActionResult AddorUpdateProblemType([FromBody]ProblemType values)
        [HttpPost]
        [Route("AddorUpdateProblemType")]
        public IActionResult AddorUpdateProblemType([FromBody] ProblemType values)
        {

            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> ProblemTypeInsertedDetails = _ProblemTypeBusiness.AddorUpdateProblemType(values, Connectionstring);
                return new JsonResult(ProblemTypeInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteProblemTypeRecord(int ProblemTypeId)
        [HttpDelete]
        [Route("DeleteProblemType")]
        public IActionResult DeleteProblemType(int Id, int ModifiedBy)
        {
            try
            {
                ProblemType values = new ProblemType();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _ProblemTypeBusiness.DeleteProblemType(values, Connectionstring);
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