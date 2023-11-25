using BusinessModels;
using BusinessModels.DWI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.DWI
{
    public interface IDigitalRtyBusinessAccess
    {
        Result<DigitalRty> GeAllDetails(DigitalRty values, string Connectionstring);
    }
}
