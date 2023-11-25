using BusinessModels;
using BusinessModels.RTY;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IAssemblyBusinessAccess
    {
        
       Result<int> SubmitAssemblyFailureDetails(AssemblyFailure values, string Connectionstring);
       Result<int> SubmitAssemblySolutionDetails(AssemblySolution values, string Connectionstring);
    }
}
