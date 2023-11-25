using BusinessLayer.Contracts.DWI;
using BusinessModels;
using BusinessModels.DWI;
using DataLayer.DWI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer.DWI
{
    public class GrapicLabelMappingBusinessAccess : IGraphicLabelMappingBusinessAccess
    {
        private readonly GraphicLabelMappingDataAccess _cpulabelmappingDataAccess = new GraphicLabelMappingDataAccess();

        #region public CollectionResult<int> GetAllGraphicLabelMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<GraphicLabelMapping> GetAllGraphicLabelMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<GraphicLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GraphicLabelMapping>()
            };

            try
            {
                responseData = _cpulabelmappingDataAccess.GetAllGraphicLabelMapping(Connectionstring, BaseUrl);

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

        #region public CollectionResult<GraphicLabelMapping> GetAllGraphicLabelMappingDetails(int PageIndex, int PageSize, string search, string Connectionstring, string BaseUrl)
        public CollectionResult<GraphicLabelMapping> GetAllGraphicLabelMappingDetails(int PageIndex, int PageSize, string search, string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<GraphicLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GraphicLabelMapping>()
            };

            try
            {
                responseData = _cpulabelmappingDataAccess.GetAllGraphicLabelMappingDetails(PageIndex, PageSize, search, Connectionstring, BaseUrl);

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

        #region public Result<GraphicLabelMapping> GetByGraphicLabelMappingId(int CPULabelMappingId, string Connectionstring, string BaseUrl)
        public Result<GraphicLabelMapping> GetByGraphicLabelMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<GraphicLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new GraphicLabelMapping()

            };

            try
            {
                responseData = _cpulabelmappingDataAccess.GetByGraphicLabelMappingId(Id, Connectionstring, BaseUrl);

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

        #region public Result<int> AddorUpdateGraphicLabelMapping(CPULabelMapping values,string Connectionstring) 
        public Result<int> AddorUpdateGraphicLabelMapping(GraphicLabelMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _cpulabelmappingDataAccess.AddorUpdateGraphicLabelMapping(values, Connectionstring);

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

        #region public Result<int> DeleteGraphLabelMapping(int CPULabelMappingId, string Connectionstring)
        public Result<int> DeleteGraphicLabelMapping(GraphicLabelMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _cpulabelmappingDataAccess.DeleteGraphicLabelMapping(values, Connectionstring);

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
    }
}