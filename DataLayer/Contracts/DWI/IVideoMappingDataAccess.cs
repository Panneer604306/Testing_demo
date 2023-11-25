using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface IVideoMappingDataAccess
    {
        CollectionResult<VideoMapping> GetAllVideoMapping(string Connectionstring, string BaseUrl);

        CollectionResult<VideoMapping> GetAllVideoMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl);

        Result<VideoMapping> GetByVideoMappingId(int Id, string Connectionstring, string BaseUrl);

        Result<int> AddorUpdateVideoMapping(VideoMapping values, string Connectionstring);

        Result<int> DeleteVideoMapping(VideoMapping values, string Connectionstring);
    }
}
