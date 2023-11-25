using BusinessModels;
using BusinessModels.DWI;
using DataLayer.Contracts.DWI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DataLayer.DWI
{
    public class DigitalRtyDataAccess : IDigitalRtyDataAccess
    {
        #region public Result<DigitalRty> GeAllDetails(string Connectionstring)
        public Result<DigitalRty> GeAllDetailsTest(DigitalRty values, string Connectionstring)
        {
            var result = new Result<DigitalRty>
            {
                Status = true,
                Message = default(string),
                Data = new DigitalRty()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetDigitalData";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("RtyStatus", values.RtyStatus.Trim());
                cmd.Parameters.AddWithValue("RtyYear", values.MonthAndYear.Year);
                cmd.Parameters.AddWithValue("RtyMonth", values.MonthAndYear.Month);
                MySqlDataReader reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    var DigitalRtyObj = new DigitalRty();
                //    result.Data.OAFPercentage = reader["OAFPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["OAFPercentage"]);
                //    result.Data.OASPercentage = reader["OASPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["OASPercentage"]);
                //    result.Data.ODFPercentage = reader["ODFPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ODFPercentage"]);
                //    result.Data.ODSPercentage = reader["ODSPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ODSPercentage"]);
                //    result.Data.OPFPercentage = reader["OPFPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["OPFPercentage"]);
                //    result.Data.OPSPercentage = reader["OPSPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["OPSPercentage"]);
                //}
                //reader.NextResult();

                //while (reader.Read())
                //{
                //    var DigitalRtyObj = new DigitalRty();
                //    result.Data.RtyStatus = reader["RtyType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["RtyType"]);
                //    result.Data.MonthAndYear = reader["MonthAndYear"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["MonthAndYear"]);
                //    result.Data.AssemblyFailure = reader["AssemblyFailure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["AssemblyFailure"]);
                //    result.Data.AssemblySolution = reader["AssemblySolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["AssemblySolution"]);
                //    result.Data.DebugFailure = reader["DebugFailure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DebugFailure"]);
                //    result.Data.DebugSolution = reader["DebugSolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DebugSolution"]);
                //    result.Data.PackingFailure = reader["PackingFailure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PackingFailure"]);
                //    result.Data.PackingSolution = reader["PackingSolution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PackingSolution"]);
                //    result.Data.AFPercentage = reader["AFPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["AFPercentage"]);
                //    result.Data.ASPercentage = reader["ASPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["ASPercentage"]);
                //    result.Data.DFPercentage = reader["DFPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DFPercentage"]);
                //    result.Data.DSPercentage = reader["DSPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["DSPercentage"]);
                //    result.Data.PFPercentage = reader["PFPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["PFPercentage"]);
                //    result.Data.PSPercentage = reader["PSPercentage"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["PSPercentage"]);

                //    //result.Data.Add(DigitalRtyObj);

                //}

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();

            return result;
        }
        #endregion


        #region public Result<DigitalRty> GeAllDetails(string Connectionstring)
        public Result<DigitalRty> GeAllDetails(DigitalRty values, string Connectionstring)
        {
            var result = new Result<DigitalRty>
            {
                Status = true,
                Message = default(string),
                Data = new DigitalRty()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetDigitalRTYDashBoard";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("RtyStatus", values.RtyStatus.Trim());

                MySqlDataReader reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    var obj = new Calculation();
                //    obj.Assembly = reader["Assembly"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Assembly"]);
                //    obj.Debug = reader["Debug"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Debug"]);
                //    obj.Packing = reader["Packing"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Packing"]);
                //    result.Data.Calculation = obj;
                //}

                //reader.NextResult();
                while (reader.Read())
                {
                    var obj = new AssemblyCal();
                    obj.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total"]);
                    obj.OneHrBelow = reader["onehrbelow"] == DBNull.Value ? 0 : Convert.ToInt32(reader["onehrbelow"]);
                    obj.OneHrAbove = reader["onehrabove"] == DBNull.Value ? 0 : Convert.ToInt32(reader["onehrabove"]);
                    obj.WIP = reader["WIP"] == DBNull.Value ? 0 : Convert.ToInt32(reader["WIP"]);
                    obj.Status = reader["Status"] == DBNull.Value ? string.Empty : reader["Status"].ToString();
                    result.Data.AssemblyCal = obj;

                }

                reader.NextResult();
                while (reader.Read())
                {
                    var obj = new DebugCal();
                    obj.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total"]);
                    obj.OneHrBelow = reader["onehrbelow"] == DBNull.Value ? 0 : Convert.ToInt32(reader["onehrbelow"]);
                    obj.OneHrAbove = reader["onehrabove"] == DBNull.Value ? 0 : Convert.ToInt32(reader["onehrabove"]);
                    obj.WIP = reader["WIP"] == DBNull.Value ? 0 : Convert.ToInt32(reader["WIP"]);
                    obj.Status = reader["Status"] == DBNull.Value ? string.Empty : reader["Status"].ToString();
                    result.Data.DebugCal = obj;
                }

                reader.NextResult();
                while (reader.Read())
                {
                    var obj = new PackingCal();
                    obj.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total"]);
                    obj.OneHrBelow = reader["onehrbelow"] == DBNull.Value ? 0 : Convert.ToInt32(reader["onehrbelow"]);
                    obj.OneHrAbove = reader["onehrabove"] == DBNull.Value ? 0 : Convert.ToInt32(reader["onehrabove"]);
                    obj.WIP = reader["WIP"] == DBNull.Value ? 0 : Convert.ToInt32(reader["WIP"]);
                    obj.Status = reader["Status"] == DBNull.Value ? string.Empty : reader["Status"].ToString();
                    result.Data.PackingCal = obj;
                }

                reader.NextResult();
                while (reader.Read())
                {
                    var obj = new Percentage();
                    obj.AssemblyPercentage = reader["AssemblyPercentage"] == DBNull.Value ? 0 : Convert.ToInt32(reader["AssemblyPercentage"]);
                    obj.DebugPercentage = reader["DebugPercentage"] == DBNull.Value ? 0 : Convert.ToInt32(reader["DebugPercentage"]);
                    obj.PackingPercentage = reader["PackingPercentage"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PackingPercentage"]);
                    result.Data.PercentageCal = obj;
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
        #endregion
    }
}
