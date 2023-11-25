using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.DWI
{
    public interface IDigitalRtyDataAccess
    {
        Result<DigitalRty> GeAllDetails(DigitalRty values, string Connectionstring);
        
    }
}
