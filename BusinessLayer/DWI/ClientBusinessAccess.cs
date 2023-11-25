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
    public class ClientBusinessAccess : IClientBusinessAccess
    {
        private readonly ClientDataAccess _clientDataAccess = new ClientDataAccess();

        public ClientBusinessAccess()
        {
        }

        #region public CollectionResult<GetStageList> GetStageList(string Connectionstring)
        public CollectionResult<GetStageList> GetStageList(string Connectionstring)
        {
            var responseData = new CollectionResult<GetStageList>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetStageList>()
            };

            try
            {
                responseData = _clientDataAccess.GetStageList(Connectionstring);

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

        #region public CollectionResult<GetStageList> GetStageList(string Connectionstring)
        public CollectionResult<GetClientDisplay> GetClientDisplay(string Connectionstring)
        {
            var responseData = new CollectionResult<GetClientDisplay>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetClientDisplay>()
            };

            try
            {
                responseData = _clientDataAccess.GetClientDisplay(Connectionstring);

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

        #region public Result<Client> GetManualByClient(string MT, string Connectionstring, string BaseUrl)
        public Result<Client> GetManualByClient(string MT, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<Client>
            {
                Status = true,
                Message = default(string),
                Data = new Client()

            };

            try
            {
                responseData = _clientDataAccess.GetManualByClient(MT, Connectionstring, BaseUrl);

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

        #region public Result<Client> GetLiveByClient(int CPULabelMappingId, string Connectionstring, string BaseUrl) 
        public Result<Client> GetLiveByClient(string MT, string Tiny, string Display, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<Client>
            {
                Status = true,
                Message = default(string),
                Data = new Client()

            };

            try
            {
                responseData = _clientDataAccess.GetLiveByClient(MT, Tiny, Display, Connectionstring, BaseUrl);

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
