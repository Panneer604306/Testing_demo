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
    public class VideoMappingBusinessAccess : IVideoMappingBusinessAccess
    {
        private readonly VideoMappingDataAccess _VideomappingDataAccess = new VideoMappingDataAccess();

        #region public CollectionResult<int> GetAllVideoMapping(string Connectionstring, string BaseUrl) 
        public CollectionResult<VideoMapping> GetAllVideoMapping(string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<VideoMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<VideoMapping>()
            };

            try
            {
                responseData = _VideomappingDataAccess.GetAllVideoMapping(Connectionstring, BaseUrl);

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

        #region public CollectionResult<int> GetAllVideoMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl) 
        public CollectionResult<VideoMapping> GetAllVideoMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {
            var responseData = new CollectionResult<VideoMapping>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<VideoMapping>()
            };

            try
            {
                responseData = _VideomappingDataAccess.GetAllVideoMappingDetails(pageIndex, pageSize, search, Connectionstring, BaseUrl);

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

        #region public Result<VideoMapping> GetByVideoMappingId(int Id, string Connectionstring, string BaseUrl) 
        public Result<VideoMapping> GetByVideoMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<VideoMapping>
            {
                Status = true,
                Message = default(string),
                Data = new VideoMapping()
            };

            try
            {
                responseData = _VideomappingDataAccess.GetByVideoMappingId(Id, Connectionstring, BaseUrl);

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

        #region public Result<int> GetVideoMappingDetails(VideoMapping values,string Connectionstring) 
        public Result<int> AddorUpdateVideoMapping(VideoMapping values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _VideomappingDataAccess.AddorUpdateVideoMapping(values, Connectionstring);

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

        #region public Result<int> DeleteVideoMapping(VideoMapping values, string Connectionstring) 
        public Result<int> DeleteVideoMapping(VideoMapping values, string Connectionstring)
        {
            var responseData = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                responseData = _VideomappingDataAccess.DeleteVideoMapping(values, Connectionstring);

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