using BusinessModels;
using BusinessModels.RTY;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;

namespace DataLayer.RTY
{
    public class ReportDataAccess
    {
        public Result<ReportManagement> GetReportManagement(string Connectionstring, string BaseUrl)
        {
            var result = new Result<ReportManagement>
            {
                Status = true,
                Message = default(string),
                Data = new ReportManagement()

            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetAllReportDetails";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Data.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total"]);
                    result.Data.Assembly = reader["Assembly"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Assembly"]);
                    result.Data.Debug = reader["Debug"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Debug"]);
                    result.Data.Packing = reader["Packing"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Packing"]);
                    result.Data.Assembly_Failure = reader["Assembly_Failure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Assembly_Failure"]);
                    result.Data.Debug_Failure = reader["Debug_Failure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Debug_Failure"]);
                    result.Data.Packing_Failure = reader["Packing_Failure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Packing_Failure"]);
                    result.Data.Open = reader["Open"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Open"]);
                    result.Data.Close = reader["Close"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Close"]);

                }
                reader.NextResult();
                result.Data.report = new List<report>();
                while (reader.Read())
                {
                    var ProblemClassObj = new report();
                    ProblemClassObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    ProblemClassObj.UWIP = reader["UWIP"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UWIP"]);
                    ProblemClassObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    ProblemClassObj.LineNo = reader["LineNo"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LineNo"]);
                    ProblemClassObj.MTM = reader["MTM"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MTM"]);
                    ProblemClassObj.Problem = reader["Problem"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Problem"]);
                    ProblemClassObj.Solution = reader["Solution"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Solution"]);
                    ProblemClassObj.OtherProblem = reader["OtherProblem"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OtherProblem"]);
                    ProblemClassObj.OtherSolution = reader["OtherSolution"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OtherSolution"]);
                    ProblemClassObj.ProblemPic = reader["ProblemPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProblemPic"]);
                    ProblemClassObj.SolutionPic = reader["SolutionPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SolutionPic"]);
                    ProblemClassObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    ProblemClassObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    ProblemClassObj.UserName = reader["UserName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UserName"]);
                    ProblemClassObj.Status = reader["Rty_Status"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Rty_Status"]);
                    ProblemClassObj.OverAllStatus = reader["Overall_status"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Overall_status"]);

                    if (ProblemClassObj.ProblemPic != null && ProblemClassObj.ProblemPic != "")
                    {
                        ProblemClassObj.ProblemPicPath = Path.Combine(BaseUrl + "Resources\\Images\\RtyPicture", ProblemClassObj.ProblemPic);
                    }
                    if (ProblemClassObj.SolutionPic != null && ProblemClassObj.SolutionPic != "")
                    {
                        ProblemClassObj.SolutionPicPath = Path.Combine(BaseUrl + "Resources\\Images\\RtyPicture", ProblemClassObj.SolutionPic);
                    }
                    result.Data.report.Add(ProblemClassObj);
                }
                //result.Message = "Record Get Successfully";

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();

            return result;
        }
        public virtual Result<ReportManagement> GetReportFilter(int PageIn, int PageSize,string Fromdate,string ToDate, string MTM, string Series, string location, string rtyStatus, string Connectionstring, string BaseUrl)
        {
            var result = new Result<ReportManagement>
            {
                Status = true,
                Message = default(string),
                Data = new ReportManagement()
            };
            var from = "";
            var to = "";
            if (MTM == null)
            {
                MTM = "";
            }
            if (Series == null)
            {
                Series = "";
            }
            if((Fromdate == null) && (ToDate==null))
            {
                from = "";
                to = "";
            }
            else
            {
                from = Fromdate.ToString();
               to = ToDate.ToString();
            }
            string rtn = "PRO_RTY_PagingReportManagement";
            //string rtn = "PRO_RTY_FilterReportManagement";
            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PageIndex", PageIn);
                cmd.Parameters.AddWithValue("PageSize", PageSize);
                cmd.Parameters.AddWithValue("FromDate", from);
                cmd.Parameters.AddWithValue("ToDate", to);
                cmd.Parameters.AddWithValue("MTM", MTM);
                cmd.Parameters.AddWithValue("Series", Series);
                cmd.Parameters.AddWithValue("location", location);
                cmd.Parameters.AddWithValue("rtyStatus", rtyStatus);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.TotalCount = reader["RecordCount"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RecordCount"]);
                }
                reader.NextResult();
                result.Data.report = new List<report>();
                while (reader.Read()) 
                {
                    var ProblemClassObj = new report();
                    ProblemClassObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    ProblemClassObj.UWIP = reader["UWIP"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UWIP"]);
                    ProblemClassObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    ProblemClassObj.MTM = reader["MTM"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MTM"]);
                    ProblemClassObj.Problem = reader["Problem"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Problem"]);
                    ProblemClassObj.Solution = reader["Solution"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Solution"]);
                    ProblemClassObj.OtherProblem = reader["OtherProblem"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OtherProblem"]);
                    ProblemClassObj.OtherSolution = reader["OtherSolution"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OtherSolution"]);
                    ProblemClassObj.ProblemPic = reader["ProblemPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProblemPic"]);
                    ProblemClassObj.SolutionPic = reader["SolutionPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SolutionPic"]);
                    ProblemClassObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    ProblemClassObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    ProblemClassObj.UserName = reader["UserName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UserName"]);
                    ProblemClassObj.Status = reader["Rty_Status"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Rty_Status"]);
                    ProblemClassObj.OverAllStatus = reader["Overall_status"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Overall_status"]);
                    ProblemClassObj.LineNo = reader["LineNo"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LineNo"]);
                    ProblemClassObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    ProblemClassObj.Owners = reader["Owners"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Owners"]);

                    if (ProblemClassObj.ProblemPic != null && ProblemClassObj.ProblemPic != "")
                    {
                        ProblemClassObj.ProblemPicPath = Path.Combine(BaseUrl + "Resources\\Images\\RtyPicture", ProblemClassObj.ProblemPic);
                    }                                                                                                                                                                                                                                                                            
                    if (ProblemClassObj.SolutionPic != null && ProblemClassObj.SolutionPic != "")
                    {
                        ProblemClassObj.SolutionPicPath = Path.Combine(BaseUrl + "Resources\\Images\\RtyPicture", ProblemClassObj.SolutionPic);
                    }
                    result.Data.report.Add(ProblemClassObj);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();

            return result;
        }
    }
}
