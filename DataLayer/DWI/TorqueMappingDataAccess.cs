using BusinessModels;
using BusinessModels.DWI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;

namespace DataLayer.DWI
{
    public class TorqueMappingDataAccess
    {
        public CollectionResult<TorqueMapping> GetAllTorqueMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<TorqueMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<TorqueMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllTorqueMapping";
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
                    var TorqueMappingObj = new TorqueMapping();
                    TorqueMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    TorqueMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    TorqueMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    TorqueMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    TorqueMappingObj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    TorqueMappingObj.Torque = reader["Torque"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Torque"]);
                    TorqueMappingObj.TorquePic = reader["TorquePic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["TorquePic"]);
                    TorqueMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    TorqueMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    TorqueMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    TorqueMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    TorqueMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    TorqueMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (TorqueMappingObj.TorquePic != "")
                    {
                        TorqueMappingObj.TorquePicPath = Path.Combine(BaseUrl, "Resources", "Images", "TorquePicture", TorqueMappingObj.TorquePic);
                    }
                    result.Data.Add(TorqueMappingObj);
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

        public CollectionResult<TorqueMapping> GetAllTorqueMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<TorqueMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<TorqueMapping>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingTorqueMapping";
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
                    var TorqueMappingObj = new TorqueMapping();
                    TorqueMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    TorqueMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    TorqueMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    TorqueMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    TorqueMappingObj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    TorqueMappingObj.Torque = reader["Torque"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Torque"]);
                    TorqueMappingObj.TorquePic = reader["TorquePic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["TorquePic"]);
                    TorqueMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    TorqueMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    TorqueMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    TorqueMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    TorqueMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    TorqueMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (TorqueMappingObj.TorquePic != "")
                    {
                        TorqueMappingObj.TorquePicPath = Path.Combine(BaseUrl, "Resources", "Images", "TorquePicture", TorqueMappingObj.TorquePic);
                    }
                    result.Data.Add(TorqueMappingObj);
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

        public Result<TorqueMapping> GetByTorqueMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var result = new Result<TorqueMapping>
            {
                Status = true,
                Message = default(string),
                Data = new TorqueMapping()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelTorqueMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var TorqueMappingObj = new TorqueMapping();
                    TorqueMappingObj.CreatedBy = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    TorqueMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    TorqueMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    TorqueMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    TorqueMappingObj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    TorqueMappingObj.Torque = reader["Torque"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Torque"]);
                    TorqueMappingObj.TorquePic = reader["TorquePic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["TorquePic"]);
                    TorqueMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    TorqueMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    TorqueMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    TorqueMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    TorqueMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    if (TorqueMappingObj.TorquePic != "")
                    {
                        TorqueMappingObj.TorquePicPath = Path.Combine(BaseUrl, "Resources", "Images", "TorquePicture", TorqueMappingObj.TorquePic);
                    }
                    result.Data = TorqueMappingObj;

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

        public Result<int> AddorUpdateTorqueMapping(TorqueMapping values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateTorqueMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("MT", values.MT.Trim());
                cmd.Parameters.AddWithValue("Series", values.Series.Trim());
                cmd.Parameters.AddWithValue("Stage", values.Stage.Trim());
                cmd.Parameters.AddWithValue("Display", values.Display.Trim());
                cmd.Parameters.AddWithValue("Torque", values.Torque);
                cmd.Parameters.AddWithValue("TorquePic", values.TorquePic);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", values.CreatedDate);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", values.Mode.Trim());

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

        public Result<int> DeleteTorqueMapping(TorqueMapping values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelTorqueMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeleteTorqueMapping");

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
    }
}
