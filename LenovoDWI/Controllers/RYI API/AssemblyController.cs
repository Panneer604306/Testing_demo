using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using BusinessModels.RTY;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace DWI_Application.Controllers.RTY_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class AssemblyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAssemblyBusinessAccess _assemblyBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AssemblyController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _assemblyBusiness = new AssemblyBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult SubmitAssemblyFailure([FromForm]AssemblyFailure values)
        [HttpPost]
        [Route("AssemblyFailure")]
        public IActionResult SubmitAssemblyFailure([FromForm] AssemblyFailure values)
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
                Result<int> SubmitAssemblyFailure = _assemblyBusiness.SubmitAssemblyFailureDetails(values, Connectionstring);
                return new JsonResult(SubmitAssemblyFailure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult SubmitAssemblySolution([FromForm]AssemblySolution values)
        [HttpPost]
        [Route("AssemblySolution")]
        public IActionResult SubmitAssemblySolution([FromForm] AssemblySolution values)
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
                Result<int> SubmitAssemblySolution = _assemblyBusiness.SubmitAssemblySolutionDetails(values, Connectionstring);
                return new JsonResult(SubmitAssemblySolution);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




    }
}
