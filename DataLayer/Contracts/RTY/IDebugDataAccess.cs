using BusinessModels;
using BusinessModels.RTY;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.RTY
{
    public interface IDebugDataAccess
    {
       
        Result<int> SubmitDebugFailureDetails(DebugFailure values, string Connectionstring);

        Result<int> SubmitDebugSolutionDetails(DebugSolution values, string Connectionstring);

    }
}
