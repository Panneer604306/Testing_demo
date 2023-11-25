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
    public class AssemblyBusinessAccess : IAssemblyBusinessAccess
    {
        private readonly AssemblyDataAccess _assemblyDataAccess = new AssemblyDataAccess();

        public AssemblyBusinessAccess()
        {
        }
                     
        #region public Result<int> SubmitAssemblyFailureDetails(AssemblyFailure values,string Connectionstring) 
        public Result<int> SubmitAssemblyFailureDetails(AssemblyFailure values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _assemblyDataAccess.SubmitAssemblyFailureDetails(values, Connectionstring);

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

        #region public Result<int> SubmitAssemblySolutionDetails(AssemblySolution values,string Connectionstring) 
        public Result<int> SubmitAssemblySolutionDetails(AssemblySolution values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = new int()
            };

            try
            {
                result = _assemblyDataAccess.SubmitAssemblySolutionDetails(values, Connectionstring);

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
