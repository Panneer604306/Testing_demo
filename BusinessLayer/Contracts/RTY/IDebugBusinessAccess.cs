using BusinessModels;
using BusinessModels.RTY;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IDebugBusinessAccess
    {
        
       Result<int> SubmitDebugFailureDetails(DebugFailure values, string Connectionstring);
       Result<int> SubmitDebugSolutionDetails(DebugSolution values, string Connectionstring);


    }
}
