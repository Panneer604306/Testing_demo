using BusinessModels;
using BusinessModels.DWI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DataLayer.DWI
{
    public class StageMappingDataAccess
    {
        public CollectionResult<StageMapping> GetAllStageMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<StageMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<StageMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllStageMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.TotalCount = Convert.ToInt32(reader[0]);
                }
                reader.NextResult();

                while (reader.Read())
                {
                    var StageMappingObj = new StageMapping();
                    StageMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    StageMappingObj.IPAddress = reader["IPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["IPAddress"]);
                    StageMappingObj.Line = reader["Line"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Line"]);
                    StageMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    StageMappingObj.ConfIPAddress = reader["ConfIPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfIPAddress"]);
                    StageMappingObj.ConfStage = reader["ConfStage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfStage"]);
                    StageMappingObj.Location = reader["Location"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Location"]);
                    StageMappingObj.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
                    StageMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    StageMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    StageMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    StageMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    StageMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    StageMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);


                    result.Data.Add(StageMappingObj);

                    result.Message = "Selected Successfully";

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

        #region public CollectionResult<StageMapping> GetAllStageMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        public CollectionResult<StageMapping> GetAllStageMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            //var result = new Result<Part>
            //{
            //    Status = true,
            //    Message = default(string),
            //    Data = new Part()

            //};
            var result = new CollectionResult<StageMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<StageMapping>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingStageMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PageIndex", pageIndex);
                cmd.Parameters.AddWithValue("PageSize", pageSize);
                cmd.Parameters.AddWithValue("Search", search);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.TotalCount = Convert.ToInt32(reader[0]);
                }
                reader.NextResult();

                while (reader.Read())
                {
                    var StageMappingObj = new StageMapping();
                    StageMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    StageMappingObj.IPAddress = reader["IPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["IPAddress"]);
                    StageMappingObj.Line = reader["Line"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Line"]);
                    StageMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    StageMappingObj.ConfIPAddress = reader["ConfIPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfIPAddress"]);
                    StageMappingObj.ConfStage = reader["ConfStage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfStage"]);
                    StageMappingObj.Location = reader["Location"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Location"]);
                    StageMappingObj.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
                    StageMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    StageMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    StageMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    StageMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    StageMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    StageMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);

                    result.Data.Add(StageMappingObj);
                    result.Message = "Get List Successfully";
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

        #region public Result<StageMapping> GetByStageMappingId(int Id, string Connectionstring)
        public Result<StageMapping> GetByStageMappingId(int Id, string Connectionstring)
        {
            var result = new Result<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new StageMapping()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelStageMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var StageMappingObj = new StageMapping();
                    StageMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    StageMappingObj.IPAddress = reader["IPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["IPAddress"]);
                    StageMappingObj.Line = reader["Line"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Line"]);
                    StageMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    StageMappingObj.ConfIPAddress = reader["ConfIPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfIPAddress"]);
                    StageMappingObj.ConfStage = reader["ConfStage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfStage"]);
                    StageMappingObj.Location = reader["Location"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Location"]);
                    StageMappingObj.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
                    StageMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    StageMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    StageMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    StageMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    StageMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    result.Data = StageMappingObj;

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

        #region public Result<StageMapping> GetLineByClientIP(string ClientIP, string Connectionstring)
        public Result<StageMapping> GetLineByIPaddress(string IPAddress, string Connectionstring)
        {
            var result = new Result<StageMapping>
            {
                Status = true,
                Message = default(string),
                Data = new StageMapping()

            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetLineByIPAddress";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("IPAddress", IPAddress);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var StageObj = new StageMapping();
                    StageObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    StageObj.Line = reader["Line"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Line"]);
                    StageObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    StageObj.ConfIPAddress = reader["ConfIPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfIPAddress"]);
                    StageObj.ConfStage = reader["ConfStage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfStage"]);                    result.Data = StageObj;
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

        #region public Result<int> AddorUpdateStageMapping(StageMapping values, string Connectionstring)
        public Result<int> AddorUpdateStageMapping(StageMapping values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateStageMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("IPAddress", values.IPAddress);
                cmd.Parameters.AddWithValue("Line", values.Line.Trim());
                cmd.Parameters.AddWithValue("Stage", values.Stage.Trim());
                cmd.Parameters.AddWithValue("ConfIPAddress", values.ConfIPAddress);
                cmd.Parameters.AddWithValue("ConfStage", values.ConfStage.Trim());
                cmd.Parameters.AddWithValue("Location", values.Location.Trim());
                cmd.Parameters.AddWithValue("IsActive", values.IsActive);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", values.CreatedDate);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", values.Mode);

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Data = Convert.ToInt32(rdr[0]);
                    result.Status = Convert.ToBoolean(rdr[1]);
                    result.Message = Convert.ToString(rdr[2]);
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
        #endregion

        #region public Result<int> DeleteStageMapping(StageMapping values, string Connectionstring)
        public Result<int> DeleteStageMapping(StageMapping values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelStageMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeleteStageMapping");

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
        #endregion
    }
}
