using BusinessLayer.Contracts.COM;
using BusinessModels;
using BusinessModels.COM;
using DataLayer.COM;
using DataLayer.Contracts.COM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer.COM
{
    public class CommonBusinessAccess : ICommonBusinessAccess
    {
        private readonly ICommonDataAccess _commonDataAccess;

        public CommonBusinessAccess()
        {
            _commonDataAccess = new CommonDataAccess();
        }

        public Result<CountStatus> GetAllCount(string Connectionstring, string line)
        {
            var responseData = new Result<CountStatus>
            {
                Status = true,
                Message = default(string),
                Data = new CountStatus()
            };

            try
            {
                responseData = _commonDataAccess.GetAllCount(Connectionstring, line);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }

        #region public CollectionResult<Series> GetAllSeriesDetails(string Connectionstring)
        public CollectionResult<AllSeries> GetAllSeriesDetails(string Connectionstring)
        {
            var responseData = new CollectionResult<AllSeries>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<AllSeries>()
            };

            try
            {
                responseData = _commonDataAccess.GetAllSeriesDetails(Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public Result<MTBySeries> GetMTBySeries(string Series, string Connectionstring) 
        public Result<MTBySeries> GetMTBySeries(string Series, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<MTBySeries>
            {
                Status = true,
                Message = default(string),
                Data = new MTBySeries()

            };

            try
            {
                responseData = _commonDataAccess.GetMTBySeries(Series, Connectionstring, BaseUrl);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public Result<UserPermissions> GetByRoleIdAccess(int RoleName, string Connectionstring)
        public Result<GetUserPermissions> GetByRoleIdAccess(int Id, string Connectionstring)
        {
            var responseData = new Result<GetUserPermissions>
            {
                Status = true,
                Message = default(string),
                Data = new GetUserPermissions()

            };

            try
            {
                responseData = _commonDataAccess.GetByRoleIdAccess(Id, Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region  public CollectionResult<ClienDisplaytList> GetClientDropDownList(string Connectionstring) 
        public CollectionResult<ClienDisplaytList> GetClientDropDownList(string Connectionstring)
        {
            var responseData = new CollectionResult<ClienDisplaytList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ClienDisplaytList>()
            };

            try
            {
                responseData = _commonDataAccess.GetClientDropDownList(Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public CollectionResult<Role> GetDropDownRoles(string Connectionstring)
        public CollectionResult<GetRoles> GetDropDownRoles(string Connectionstring)
        {
            var responseData = new CollectionResult<GetRoles>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetRoles>()
            };

            try
            {
                responseData = _commonDataAccess.GetDropDownRoles(Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public CollectionResult<GetPartList> GetPartList(string Connectionstring)
        public CollectionResult<GetPartList> GetPartList(string Connectionstring)
        {
            var responseData = new CollectionResult<GetPartList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetPartList>()
            };

            try
            {
                responseData = _commonDataAccess.GetPartList(Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public Result<Part> GetByPartId(int Id, string Connectionstring) 
        public CollectionResult<GetPartByProduct> GetPartByProduct(string Product, string Connectionstring)
        {
            var responseData = new CollectionResult<GetPartByProduct>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetPartByProduct>()
            };

            try
            {
                responseData = _commonDataAccess.GetPartByProduct(Product, Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public Result<GetRTYProductId> GetRTYProductByMT(string MT, string Connectionstring)
        public Result<GetRTYProductId> GetRTYProductByMT(string MT, string Connectionstring)
        {
            var responseData = new Result<GetRTYProductId>
            {
                Status = true,
                Message = default(string),
                Data = new GetRTYProductId()

            };

            try
            {
                responseData = _commonDataAccess.GetRTYProductByMT(MT, Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public CollectionResult<GetAllSatge> GetAllStage(string Connectionstring)
        public CollectionResult<GetAllSatge> GetAllStage(string Connectionstring)
        {
            var responseData = new CollectionResult<GetAllSatge>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetAllSatge>()
            };

            try
            {
                responseData = _commonDataAccess.GetAllStage(Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public CollectionResult<GetProblemClassList> GetByProblemClass(string Id, string Connectionstring) 
        public CollectionResult<GetProblemClassList> GetByProblemClass(string ProblemType, string Connectionstring)
        {
            var result = new CollectionResult<GetProblemClassList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetProblemClassList>()
            };

            try
            {
                result = _commonDataAccess.GetByProblemClass(ProblemType, Connectionstring);

                if (!result.Status)
                {
                    throw new Exception(result.Message);
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
        #endregion

        #region public Result<ProblemType> GetByProblemType(int Id, string Connectionstring) 
        public CollectionResult<GetProblemTypeList> GetByProblemType(string PartName, string Connectionstring)
        {
            var responseData = new CollectionResult<GetProblemTypeList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetProblemTypeList>()
            };

            try
            {
                responseData = _commonDataAccess.GetByProblemType(PartName, Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public Result<ProblemType> GetBySolutionType(string PartName, string Connectionstring) 
        public CollectionResult<GetSolutionTypeList> GetBySolutionType(string PartName, string Connectionstring)
        {
            var responseData = new CollectionResult<GetSolutionTypeList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetSolutionTypeList>()
            };

            try
            {
                responseData = _commonDataAccess.GetBySolutionType(PartName, Connectionstring);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        #endregion

        #region public CollectionResult<GetSolutionClassList> GetBySolutionClass(string ProblemType, string Connectionstring) 
        public CollectionResult<GetSolutionClassList> GetBySolutionClass(string ProblemType, string Connectionstring)
        {
            var result = new CollectionResult<GetSolutionClassList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetSolutionClassList>()
            };

            try
            {
                result = _commonDataAccess.GetBySolutionClass(ProblemType, Connectionstring);

                if (!result.Status)
                {
                    throw new Exception(result.Message);
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
        #endregion


        #region public CollectionResult<GetOwners> GetByOwners(string UWIP, string Stage, string Connectionstring) 
        public CollectionResult<GetOwnersList> GetByOwners(string UWIP, string Stage, string Connectionstring)
        {
            var result = new CollectionResult<GetOwnersList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetOwnersList>()
            };

            try
            {
                result = _commonDataAccess.GetByOwners(UWIP, Stage, Connectionstring);

                if (!result.Status)
                {
                    throw new Exception(result.Message);
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
        #endregion
    }
}
