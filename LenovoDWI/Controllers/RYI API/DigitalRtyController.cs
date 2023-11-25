using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DWI_Lenovo.Controllers.RYI_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class DigitalRtyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDigitalRtyBusinessAccess _digitalRtyBusinessAccess;

        public DigitalRtyController(IConfiguration configuration)
        {
            _configuration = configuration;
            _digitalRtyBusinessAccess = new DigitalRtyBusinessAccess();
        }

        #region public IActionResult GetAllClientDetails()
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllClientDetails(string RtyStatus, DateTime monthAndYear)
        {

            var responseData = new Result<DigitalRty>
            {
                Status = true,
                Message = default(string),
                Data = new DigitalRty()

            };

            try
            {
                DigitalRty values = new DigitalRty();
                values.RtyStatus = RtyStatus;
                values.MonthAndYear = monthAndYear;

                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _digitalRtyBusinessAccess.GeAllDetails(values, Connectionstring);
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
