using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts.RTY;
using BusinessLayer.RTY;
using BusinessModels;
using BusinessModels.RTY;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;

namespace DWI_Lenovo.Controllers.RYI_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ReportController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IReportBusinessAccess _reportBusinessAccess;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ReportController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _reportBusinessAccess = new ReportBusinessAccess();
            _hostingEnvironment = env;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var responseData = new Result<ReportManagement>
            {
                Status = true,
                Message = default(string),
                Data = new ReportManagement()
            };
            try
            {

                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _reportBusinessAccess.GetReportManagement(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("GetByFilter")]
        public IActionResult GetReportManagement([FromBody] GetByFilter values)
        {
            var responseData = new Result<ReportManagement>
            {
                Status = true,
                Message = default(string),
                Data = new ReportManagement()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _reportBusinessAccess.GetReportFilter(values.PageIn, values.PageSize,values.Fromdate, values.ToDate, values.MTM, values.Series, values.location, values.rtyStatus, Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}


