using BusinessLayer.COM;
using BusinessLayer.Contracts.COM;
using BusinessModels;
using BusinessModels.COM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.ObjectModel;

namespace DWI_Lenovo.Controllers.COM_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CommonController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICommonBusinessAccess _commonBusinessAccess;
        public CommonController(IConfiguration configuration)
        {
            _configuration = configuration;
            _commonBusinessAccess = new CommonBusinessAccess();
        }


        #region public IActionResult GetByRoleIdAccess(string RoleName)
        [HttpGet]
        [Route("GetByRoleIdAccess")]
        public IActionResult GetByRoleIdAccess(int Id)
        {
            var responseData = new Result<GetUserPermissions>
            {
                Status = true,
                Message = default(string),
                Data = new GetUserPermissions()

            };
            try
            {
                if (Id > 0)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _commonBusinessAccess.GetByRoleIdAccess(Id, Connectionstring);
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

        #region public IActionResult GetAllSeriesDetails()
        [HttpGet]
        [Route("GetAllSeries")]
        public IActionResult GetAllSeriesDetails()
        {
            var result = new CollectionResult<AllSeries>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<AllSeries>()
            };


            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                result = _commonBusinessAccess.GetAllSeriesDetails(Connectionstring);
                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetMTBySeries(String Series)
        [HttpGet]
        [Route("GetMTBySeries")]
        public IActionResult GetMTBySeries(String Series)
        {
            var responseData = new Result<MTBySeries>
            {
                Status = true,
                Message = default(string),
                Data = new MTBySeries()

            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _commonBusinessAccess.GetMTBySeries(Series, Connectionstring, BaseUrl);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        [HttpGet]
        [Route("GetCount")]
        public IActionResult GetAllCount(string line)
        {
            var responseData = new Result<CountStatus>
            {
                Status = true,
                Message = default(string),
                Data = new CountStatus()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                responseData = _commonBusinessAccess.GetAllCount(Connectionstring, line);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message.ToString();
                return new JsonResult(responseData);
            }
        }

        //[HttpGet]
        //[Route("GetCountDebug")]
        //public IActionResult GetCountDebug()
        //{
        //    var responseData = new CollectionResult<CountStatus>
        //    {
        //        Status = true,
        //        Message = default(string),
        //        Data = new Collection<CountStatus>()
        //    };
        //    try
        //    {
        //        string mode = "Debug";
        //        string Connectionstring = _configuration.GetConnectionString("Default");
        //        string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        //        responseData = _commonBusinessAccess.GetAllCount(Connectionstring, mode);
        //        return new JsonResult(responseData);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpGet]
        //[Route("GetCountPacking")]
        //public IActionResult GetCountPacking()
        //{
        //    var responseData = new CollectionResult<CountStatus>
        //    {
        //        Status = true,
        //        Message = default(string),
        //        Data = new Collection<CountStatus>()
        //    };
        //    try
        //    {
        //        string mode = "Packing";
        //        string Connectionstring = _configuration.GetConnectionString("Default");
        //        string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        //        responseData = _commonBusinessAccess.GetAllCount(Connectionstring, mode);
        //        return new JsonResult(responseData);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region public IActionResult LiveMTMapping(string MT)
        [HttpGet]
        [Route("GetClientDropDownList")]
        public IActionResult GetClientDropDownList()
        {
            var responseData = new CollectionResult<ClienDisplaytList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ClienDisplaytList>()
            };

            try
            {
                //if (Id != "")
                //{
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _commonBusinessAccess.GetClientDropDownList(Connectionstring);
                return new JsonResult(responseData);
                //}
                //else
                //{
                //    return BadRequest(new { Status = false, Message = "Invalid parameter value detected.!!!", Data = 0 });
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetDropDownRoles()
        [HttpGet]
        [Route("GetDropDownRoles")]
        public IActionResult GetDropDownRoles()
        {
            var result = new CollectionResult<GetRoles>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetRoles>()
            };

            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                result = _commonBusinessAccess.GetDropDownRoles(Connectionstring);
                return new JsonResult(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetPartByProduct(string Product)
        [HttpGet]
        [Route("GetPartByProduct")]
        public IActionResult GetPartByProduct(string Product)
        {
            var responseData = new CollectionResult<GetPartByProduct>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetPartByProduct>()
            };

            try
            {
                if (Product != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _commonBusinessAccess.GetPartByProduct(Product, Connectionstring);
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

        #region public IActionResult GetProductByMT(string MT)
        [HttpGet]
        [Route("GetProductByMT")]
        public IActionResult GetProductByMT(string MT)
        {
            var responseData = new Result<GetRTYProductId>
            {
                Status = true,
                Message = default(string),
                Data = new GetRTYProductId()

            };
            try
            {
                if (MT != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _commonBusinessAccess.GetRTYProductByMT(MT, Connectionstring);
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

        #region public IActionResult GetPartList()
        [HttpGet]
        [Route("GetPartList")]
        public IActionResult GetPartList()
        {
            var responseData = new CollectionResult<GetPartList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetPartList>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _commonBusinessAccess.GetPartList(Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetByProblemClass(string ProblemType)
        [HttpGet]
        [Route("GetByProblemClass")]
        public IActionResult GetByProblemClass(string ProblemType)
        {
            var responseData = new CollectionResult<GetProblemClassList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetProblemClassList>()
            };

            try
            {
                if (ProblemType != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _commonBusinessAccess.GetByProblemClass(ProblemType, Connectionstring);
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

        #region public IActionResult GetByProblemType(string PartName)
        [HttpGet]
        [Route("GetByProblemType")]
        public IActionResult GetByProblemType(string PartName)
        {
            var responseData = new CollectionResult<GetProblemTypeList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetProblemTypeList>()
            };

            try
            {
                if (PartName != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _commonBusinessAccess.GetByProblemType(PartName, Connectionstring);
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

        #region public IActionResult GetByProblemType(string PartName)
        [HttpGet]
        [Route("GetBySolutionType")]
        public IActionResult GetBySolutionType(string PartName)
        {
            var responseData = new CollectionResult<GetSolutionTypeList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetSolutionTypeList>()
            };

            try
            {
                if (PartName != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _commonBusinessAccess.GetBySolutionType(PartName, Connectionstring);
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

        #region public IActionResult GetBySolutionClass(string SolutionType)
        [HttpGet]
        [Route("GetBySolutionClass")]
        public IActionResult GetBySolutionClass(string SolutionType)
        {
            var responseData = new CollectionResult<GetSolutionClassList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetSolutionClassList>()
            };

            try
            {
                if (SolutionType != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _commonBusinessAccess.GetBySolutionClass(SolutionType, Connectionstring);
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

        #region public IActionResult GetBySolutionClass(string UWIP, string Stage)
        [HttpGet]
        [Route("GetByOwner")]
        public IActionResult GetByOwners(string UWIP, string Stage)
        {
            var responseData = new CollectionResult<GetOwnersList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetOwnersList>()
            };

            try
            {
                if (UWIP != null && Stage != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    responseData = _commonBusinessAccess.GetByOwners(UWIP, Stage, Connectionstring);
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

    }
}
