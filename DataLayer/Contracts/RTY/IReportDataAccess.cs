using BusinessModels;
using BusinessModels.RTY;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contracts.RTY
{
    public interface IReportDataAccess
    {
        Result<ReportManagement> GetReportManagement(string Connectionstring, string BaseUrl);
        Result<ReportManagement> GetReportFilter(DateTime Fromdate, DateTime ToDate, string MTM, string Series, string location, string rtyStatus, string Connectionstring, string BaseUrl);
    }
}

