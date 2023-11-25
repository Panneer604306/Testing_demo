using BusinessLayer.Contracts.DWI;
using BusinessModels;
using BusinessModels.RTY;
using DataLayer.DWI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer.DWI
{
    public class PackingBusinessAccess : IPackingBusinessAccess
    {
        private readonly PackingDataAccess _packingDataAccess = new PackingDataAccess();

        public PackingBusinessAccess()
        {
        }

        #region public Result<int> SubmitPackingFailureDetails(PackingFailure values,string Connectionstring) 
        public Result<int> SubmitPackingFailureDetails(PackingFailure values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _packingDataAccess.SubmitPackingFailureDetails(values, Connectionstring);

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

        #region public Result<int> SubmitPackingSolutionDetails(PackingSolution values,string Connectionstring) 
        public Result<int> SubmitPackingSolutionDetails(PackingSolution values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _packingDataAccess.SubmitPackingSolutionDetails(values, Connectionstring);

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
