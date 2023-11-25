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
    public class ProblemClassController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IProblemClassBusinessAccess _ProblemClassBusiness;

        public ProblemClassController(IConfiguration configuration)
        {
            _configuration = configuration;
            _ProblemClassBusiness = new ProblemClassBusinessAccess();
        }

        #region public IActionResult GetAllProblemClass()
        [HttpGet]
        [Route("GetAllProblemClass")]
        public IActionResult GetAllProblemClass()
        {
            var responseData = new CollectionResult<ProblemClass>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProblemClass>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _ProblemClassBusiness.GetAllProblemClass(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region public IActionResult getProblemClassDetails()
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetProblemClassDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<ProblemClass>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ProblemClass>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _ProblemClassBusiness.GetAllProblemClassDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByProblemClassId(int Id)
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByProblemClassId(int Id)
        {
            var responseData = new Result<ProblemClass>
            {
                Status = true,
                Message = default(string),
                Data = new ProblemClass()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _ProblemClassBusiness.GetByProblemClassId(Id, Connectionstring);
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


        #region public IActionResult AddorUpdateProblemClass([FromBody]ProblemClass values)
        [HttpPost]
        [Route("AddorUpdateProblemClass")]
        public IActionResult AddorUpdateProblemClass([FromBody] ProblemClass values)
        {

            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> ProblemClassInsertedDetails = _ProblemClassBusiness.AddorUpdateProblemClass(values, Connectionstring);
                return new JsonResult(ProblemClassInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteProblemClassRecord(int ProblemClassId)
        [HttpDelete]
        [Route("DeleteProblemClass")]
        public IActionResult DeleteProblemClass(int Id, int ModifiedBy)
        {
            try
            {
                ProblemClass values = new ProblemClass();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _ProblemClassBusiness.DeleteProblemClass(values, Connectionstring);
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