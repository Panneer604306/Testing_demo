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
    public class DigitalRtyBusinessAccess : IDigitalRtyBusinessAccess
    {
        private readonly DigitalRtyDataAccess _digitalRtyDataAccess = new DigitalRtyDataAccess();

        public DigitalRtyBusinessAccess()
        {
        }

        #region public CollectionResult<int> GeAllDetails(string Connectionstring) 
        public Result<DigitalRty> GeAllDetails(DigitalRty values, string Connectionstring)
        {
            var responseData = new Result<DigitalRty>
            {
                Status = true,
                Message = default(string),
                Data = new DigitalRty()

            };

            try
            {
                responseData = _digitalRtyDataAccess.GeAllDetails(values, Connectionstring);

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
