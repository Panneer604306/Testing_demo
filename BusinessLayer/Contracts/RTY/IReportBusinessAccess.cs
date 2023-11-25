using BusinessModels;
using BusinessModels.RTY;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.RTY
{
    public interface IReportBusinessAccess
    {
        Result<ReportManagement> GetReportManagement(string Connectionstring, string BaseUrl);
        Result<ReportManagement> GetReportFilter(int PageIn, int PageSize, string Fromdate, string ToDate, string MTM, string Series, string location, string rtyStatus, string Connectionstring, string BaseUrl);
    }
}
