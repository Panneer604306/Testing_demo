using BusinessLayer.Contracts.RTY;
using BusinessModels;
using BusinessModels.RTY;
using DataLayer.Contracts.RTY;
using DataLayer.RTY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer.RTY
{
    public class ReportBusinessAccess : IReportBusinessAccess
    {
        private readonly ReportDataAccess _reportDataAccess = new ReportDataAccess();
        public Result<ReportManagement> GetReportManagement(string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<ReportManagement>
            {
                Status = true,
                Message = default(string),
                Data = new ReportManagement()
            };

            try
            {
                responseData = _reportDataAccess.GetReportManagement(Connectionstring, BaseUrl);

                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
        public Result<ReportManagement> GetReportFilter(int PageIn,int PageSize,string Fromdate, string ToDate, string MTM, string Series, string location, string rtyStatus, string Connectionstring, string BaseUrl)
        {
            var responseData = new Result<ReportManagement>
            {
                Status = true,
                Message = default(string),
                Data = new ReportManagement()
            };

            try
            {
                //responseData = _reportDataAccess.GetReportFilter(PgIndex, PgSize,Fromdate, ToDate, MTM, Series, location, rtyStatus, Connectionstring, BaseUrl);
                responseData = _reportDataAccess.GetReportFilter(PageIn,PageSize,Fromdate, ToDate, MTM, Series, location, rtyStatus, Connectionstring, BaseUrl);
                if (!responseData.Status)
                {
                    throw new Exception(responseData.Message);
                }
            }
            catch (Exception ex)
            {
                responseData.Status = false;
                responseData.Message = ex.Message;
            }
            return responseData;
        }
    }
}
