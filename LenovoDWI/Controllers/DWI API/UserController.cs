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
using DWI_Application.MailTemplates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DWI_Application.Controllers.DWI_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IUserBusinessAccess _userBusiness;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly SentToMail _sentToMail;

        public UserController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _userBusiness = new UserBusinessAccess();
            _hostingEnvironment = env;
            _sentToMail = new SentToMail(_configuration);
        }

        #region public IActionResult GetAllUser()
        [HttpGet]
        [Route("GetUserDetails")]
        public IActionResult GetAllSolutionClass()
        {
            var responseData = new CollectionResult<User>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<User>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");

                responseData = _userBusiness.GetAllUser(Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult getUserDetails()
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllUserDetails(int pageIndex, int pageSize, string search)
        {
            var responseData = new CollectionResult<User>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<User>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _userBusiness.GetAllUserDetails(pageIndex, pageSize, search, Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByUserId(int roleId)
        [HttpGet]
        [Route("GetByUserId")]
        public IActionResult GetByUserId(int Id)
        {
            var responseData = new Result<User>
            {
                Status = true,
                Message = default(string),
                Data = new User()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _userBusiness.GetByUserId(Id, Connectionstring);
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

        #region public IActionResult AddorUpdateUserDetails([FromBody]User values) 
        [HttpPost]
        [Route("AddorUpdateUser")]
        public IActionResult AddorUpdateUser([FromBody] User values)
        {
            try
            {
                values.CreatedDate = DateTime.UtcNow;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> UserInsertedDetails = _userBusiness.AddorUpdateUser(values, Connectionstring);

                if (UserInsertedDetails.Status && UserInsertedDetails.TotalCount == 1)
                {
                    var webRoot = _hostingEnvironment.ContentRootPath; //get wwwroot Folder  

                    //Get TemplateFile located at wwwroot/Templates/EmailTemplate/Register_EmailTemplate.html  
                    //var pathToFile = _hostingEnvironment.ContentRootPath
                    //        + Path.DirectorySeparatorChar.ToString()
                    //        + "MailTemplates"
                    //        + Path.DirectorySeparatorChar.ToString()
                    //        + "HtmlTemplates"
                    //        + Path.DirectorySeparatorChar.ToString()
                    //        + "htmlpage.html";

                    string pathToFile = Path.Combine(_hostingEnvironment.ContentRootPath, "MailTemplates", "HtmlTemplates", "htmlpage.html");
                    string subject = UserInsertedDetails.Message == "Inserted Successfully" ? "Newly Created User"  : "Recently Updated Password ";
                    string body = string.Empty;
                    string fname = values.FirstName;
                    string lname = values.LastName;
                    string email = values.EmailId;
                    string password = values.Password;

                    using (StreamReader reader = new StreamReader(pathToFile))
                    {
                        body = reader.ReadToEnd();
                    }
                    body = body.Replace("{Firstname}", fname);
                    body = body.Replace("{Lastname}", lname);
                    body = body.Replace("{Email}", email);
                    body = body.Replace("{Password}", password);

                    _sentToMail.SentMail(values.EmailId, subject, body);
                }
                return new JsonResult(UserInsertedDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult DeleteUserRecord(User values)
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int Id, int ModifiedBy)
        {
            try
            {
                User values = new User();
                values.Id = Id;
                values.ModifiedBy = ModifiedBy;
                values.ModifiedDate = DateTime.UtcNow;
                string Connectionstring = _configuration.GetConnectionString("Default");
                Result<int> responseData = _userBusiness.DeleteUser(values, Connectionstring);
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
