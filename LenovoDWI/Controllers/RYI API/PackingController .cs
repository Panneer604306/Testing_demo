using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using BusinessModels.RTY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace DWI_Application.Controllers.RTY_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class PackingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IPackingBusinessAccess _packingBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PackingController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _packingBusiness = new PackingBusinessAccess();
            _hostingEnvironment = env;

        }

        #region public IActionResult SubmitPackingFailure([FromForm]PackingFailure values)
        [HttpPost]
        [Route("PackingFailure")]
        public IActionResult SubmitPackingFailure([FromForm] PackingFailure values)
        {
            try
            {

                if (values.ProblemPic != null)
                {
                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "RtyPicture");
                    // If directory does not exist, don't even try   
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, values.ProblemPic.FileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.ProblemPic.CopyTo(stream);
                    }
                    values.LogicalFileName = values.ProblemPic.FileName.ToString();
                }
                values.CreatedDate = DateTime.UtcNow.Date;

                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> SubmitPackingFailure = _packingBusiness.SubmitPackingFailureDetails(values, Connectionstring);
                return new JsonResult(SubmitPackingFailure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult SubmitPackingSolution([FromForm]PackingSolution values)
        [HttpPost]
        [Route("PackingSolution")]
        public IActionResult SubmitPackingSolution([FromForm] PackingSolution values)
        {
            try
            {
                if (values.SolutionPic != null)
                {

                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "RtyPicture");
                    // If directory does not exist, don't even try   
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string fullPath = Path.Combine(root, values.SolutionPic.FileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        values.SolutionPic.CopyTo(stream);
                    }
                    values.LogicalFileName = values.SolutionPic.FileName.ToString();
                }

                values.ModifiedDate = DateTime.UtcNow.Date;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> SubmitPackingSolution = _packingBusiness.SubmitPackingSolutionDetails(values, Connectionstring);
                return new JsonResult(SubmitPackingSolution);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
