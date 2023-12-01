using AutoMapper;
using BusinessLayer;
using BusinessLayer.Contracts;
using BusinessModels;
using DWI_Application.MailTemplates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DWIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginBusinessAccess _loginBusiness;
        private readonly SentToMail _sentToMail;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public LoginController(IConfiguration configuration, IHostingEnvironment env, IMapper mapper)
        {
            _configuration = configuration;
            _loginBusiness = new LoginBusinessAccess();
            _sentToMail = new SentToMail(_configuration);
            _hostingEnvironment = env;
            _mapper = mapper;

        }

        #region Login Validation  
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin data)
        {
            IActionResult response = Unauthorized();
            string Connectionstring = _configuration.GetConnectionString("Default");
            Result<Login> user = _loginBusiness.GetLoginDetails(data.Username, data.Password, Connectionstring);
            if (user.Status == true)
            {
                var userViewModel = _mapper.Map<UserLogin>(user.Data);
                user.Data.AuthToken = GenerateJSONWebToken(userViewModel);
                Result<int> Loginuser = _loginBusiness.UpdateUserAuthtoken(user.Data.AuthToken, data.Username, Connectionstring);
                response = Ok(new { user, Status = true, Message = "Success" });
            }
            return response;
        }
        #endregion

        #region GenerateJWT  
        private string GenerateJSONWebToken(UserLogin userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

        #region ForgetPassword
        [AllowAnonymous]
        [HttpGet]
        [Route("ForgetPassword")]

        //Testing purpose validation
        public IActionResult ForgetPassword(string EmailId)
        {
            try
            {
                //Email Notification purpose checking in the testing purpose due to taking the session
                if (EmailId != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    Result<Login> login = _loginBusiness.ForgetPassword(EmailId, Connectionstring);
                    if (login.Data.EmailId != null)
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
                        string subject = "Forget Password";
                        string body = string.Empty;
                        //string body = string.Empty;
                        string fname = login.Data.FirstName;
                        string lname = login.Data.LastName;
                        string email = login.Data.EmailId;
                        string password = login.Data.Password;

                        using (StreamReader reader = new StreamReader(pathToFile))
                        {
                            body = reader.ReadToEnd();
                        }
                        body = body.Replace("{Firstname}", fname);
                        body = body.Replace("{Lastname}", lname);
                        body = body.Replace("{Email}", email);
                        body = body.Replace("{Password}", password);

                        _sentToMail.SentMail(login.Data.EmailId, subject, body);
                        login.Message = "Mail sent through your mail";
                        return new JsonResult(login);
                    }
                    else
                    {
                        login.Message = "Invalid Mail Id";
                        login.Status = false;
                        return new JsonResult(login);
                    }
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

        #region public string IPAdresssget()
        [HttpGet]
        [Route("GetIP")]
        public string IPAdresssget()
        {
            try
            {
                string hostName = Dns.GetHostName();
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                myIP = "192.168.1.64";
                return myIP;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
