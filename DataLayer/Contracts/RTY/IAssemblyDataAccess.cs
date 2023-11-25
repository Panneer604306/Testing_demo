using BusinessModels;
using BusinessModels.RTY;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.RTY
{
    public interface IAssemblyDataAccess
    {
       
        Result<int> SubmitAssemblyFailureDetails(AssemblyFailure values, string Connectionstring);

        Result<int> SubmitAssemblySolutionDetails(AssemblySolution values, string Connectionstring);

    }
}
