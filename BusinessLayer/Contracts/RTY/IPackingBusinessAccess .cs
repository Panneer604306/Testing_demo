using BusinessModels;
using BusinessModels.RTY;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IPackingBusinessAccess
    {
        
       Result<int> SubmitPackingFailureDetails(PackingFailure values, string Connectionstring);
       Result<int> SubmitPackingSolutionDetails(PackingSolution values, string Connectionstring);


    }
}
