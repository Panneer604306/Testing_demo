using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

namespace DWI_Application.Controllers.RTY_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class DebugController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDebugBusinessAccess _debugBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DebugController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _debugBusiness = new DebugBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult SubmitDebugFailure([FromForm]DebugFailure values)
        [HttpPost]
        [Route("DebugFailure")]
        public IActionResult SubmitDebugFailure([FromForm] DebugFailure values)
        {
            try
            {

                DebugFailure inputRequest = new DebugFailure();


                if (values.ProblemPic != null)
                {

                    string root = Path.Combine(_hostingEnvironment.ContentRootPath, "Resources", "Images", "RtyPicture");
                    // If directory does not exist, don't even try   
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    if (values.ProblemPic != null)
                    {
                        string fullPath = Path.Combine(root, values.ProblemPic.FileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            values.ProblemPic.CopyTo(stream);
                        }
                    }
                    inputRequest.LogicalFileName = values.ProblemPic.FileName;
                }

                if (values.OtherProblem == "undefined")
                    values.OtherProblem = null;
                inputRequest.UWIP = values.UWIP;
                inputRequest.MTM = values.MTM;
                inputRequest.Product = values.Product;
                inputRequest.SerialNo = values.SerialNo;
                inputRequest.LineNo = values.LineNo;
                inputRequest.Series = values.Series;
                inputRequest.Stage = values.Stage;
                inputRequest.PartName = values.PartName;
                inputRequest.ProblemType = values.ProblemType;
                inputRequest.ProblemClass = values.ProblemClass;
                inputRequest.Problem = values.Problem;
                inputRequest.OtherProblem = values.OtherProblem;
                inputRequest.Owners = values.Owners;

                inputRequest.RtyId = values.RtyId;

                inputRequest.CreatedBy = values.CreatedBy;
                inputRequest.CreatedDate = DateTime.UtcNow.Date;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> SubmitDebugFailure = _debugBusiness.SubmitDebugFailureDetails(inputRequest, Connectionstring);
                return new JsonResult(SubmitDebugFailure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult SubmitDebugSolution([FromForm] DebugSolution values)
        [HttpPost]
        [Route("DebugSolution")]
        public IActionResult SubmitDebugSolution([FromForm] DebugSolution values)
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
                    if (values.SolutionPic != null)
                    {
                        string fullPath = Path.Combine(root, values.SolutionPic.FileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            values.SolutionPic.CopyTo(stream);
                        }
                    }
                    values.LogicalFileName = values.SolutionPic.FileName.ToString();
                }
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> SubmitDebugSolution = _debugBusiness.SubmitDebugSolutionDetails(values, Connectionstring);
                return new JsonResult(SubmitDebugSolution);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
