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
    public class DebugBusinessAccess : IDebugBusinessAccess
    {
        private readonly DebugDataAccess _debugDataAccess = new DebugDataAccess();

        public DebugBusinessAccess()
        {
        }
                     
        #region public Result<int> SubmitDebugFailureDetails(DebugFailure values,string Connectionstring) 
        public Result<int> SubmitDebugFailureDetails(DebugFailure values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _debugDataAccess.SubmitDebugFailureDetails(values, Connectionstring);

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

        #region public Result<int> SubmitDebugSolutionDetails(DebugSolution values,string Connectionstring) 
        public Result<int> SubmitDebugSolutionDetails(DebugSolution values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _debugDataAccess.SubmitDebugSolutionDetails(values, Connectionstring);

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
