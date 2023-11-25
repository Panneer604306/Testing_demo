using BusinessModels;
using BusinessModels.DWI;
using BusinessModels.RTY;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DataLayer.DWI
{
    public class AssemblyDataAccess
    {

        public Result<int> SubmitAssemblyFailureDetails(AssemblyFailure values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = default(int)
            };
            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_SubmitAssemblyFailure";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UWIP", values.UWIP);
                cmd.Parameters.AddWithValue("MTM", values.MTM);
                cmd.Parameters.AddWithValue("SerialNo", values.SerialNo);
                cmd.Parameters.AddWithValue("Product", values.Product);
                cmd.Parameters.AddWithValue("Series", values.Series);
                cmd.Parameters.AddWithValue("LineNo", values.LineNo);
                cmd.Parameters.AddWithValue("Stage", values.Stage);
                cmd.Parameters.AddWithValue("PartName", values.PartName);
                cmd.Parameters.AddWithValue("ProblemType", values.ProblemType);
                cmd.Parameters.AddWithValue("ProblemClass", values.ProblemClass);
                cmd.Parameters.AddWithValue("Problem", values.Problem);
                cmd.Parameters.AddWithValue("OtherProblem", values.OtherProblem);
                cmd.Parameters.AddWithValue("ProblemPic", values.LogicalFileName);
                cmd.Parameters.AddWithValue("RtyId", values.RtyId);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("Owners", values.Owners);

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Data = Convert.ToInt32(rdr[0]);
                    result.Message = Convert.ToString(rdr[1]);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            conn.Close();
            return result;
        }

        public Result<int> SubmitAssemblySolutionDetails(AssemblySolution values, string Connectionstring)
        {
            var result = new Result<int>
            {
                Status = true,
                Message = default(string),
                Data = default(int)
            };
            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string rtn = "PRO_RTY_SubmitAssemblySolution";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UWIPP", values.UWIP);
                cmd.Parameters.AddWithValue("MTM", values.MTM);
                cmd.Parameters.AddWithValue("SerialNo", values.SerialNo);
                cmd.Parameters.AddWithValue("Product", values.Product);
                cmd.Parameters.AddWithValue("Series", values.Series);
                cmd.Parameters.AddWithValue("LineNo", values.LineNo);
                cmd.Parameters.AddWithValue("Stage", values.Stage);
                cmd.Parameters.AddWithValue("PartName", values.PartName);
                cmd.Parameters.AddWithValue("SolutionType", values.SolutionType);
                cmd.Parameters.AddWithValue("SolutionClass", values.SolutionClass);
                cmd.Parameters.AddWithValue("Solution", values.Solution);
                cmd.Parameters.AddWithValue("OtherSolution", values.OtherSolution);
                cmd.Parameters.AddWithValue("SolutionPic", values.LogicalFileName);
                cmd.Parameters.AddWithValue("RtyId", values.RtyId);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("Owners", values.Owners);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Data = Convert.ToInt32(rdr[0]);
                    result.Message = Convert.ToString(rdr[1]);
                    if (result.Message == "")
                        result.Message = "If Not Available the Failure info for that Number";
                }

                rdr.Close();
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
