using BusinessModels;
using BusinessModels.DWI;
using DataLayer.Contracts.DWI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;

namespace DataLayer.DWI
{
    public class SafetyDataAccess : ISafetyDataAccess
    {

        public CollectionResult<SafetyMapping> GetAllSafetyMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<SafetyMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SafetyMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllSafetyMapping";
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
                    var PartPicMappingObj = new SafetyMapping();
                    PartPicMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    PartPicMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    PartPicMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    PartPicMappingObj.Stage = reader["stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["stage"]);
                    PartPicMappingObj.SafetyDescription = reader["SafetyDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SafetyDescription"]);
                    PartPicMappingObj.SafetyPic = reader["SafetyPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SafetyPic"]);
                    PartPicMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    PartPicMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    PartPicMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    PartPicMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    PartPicMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    PartPicMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (PartPicMappingObj.SafetyPic != "")
                    {
                        PartPicMappingObj.SafetyPicPath = Path.Combine(BaseUrl, "Resources", "Images", "SafetyPicture", PartPicMappingObj.SafetyPic);
                    }
                    result.Data.Add(PartPicMappingObj);
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

        public CollectionResult<SafetyMapping> GetAllSafetyDetails(int PageIndex, int PageSize, string search, string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<SafetyMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<SafetyMapping>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingSafetyMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PageIndex", PageIndex);
                cmd.Parameters.AddWithValue("PageSize", PageSize);
                cmd.Parameters.AddWithValue("Search", search);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.TotalCount = Convert.ToInt32(reader[0]);
                }
                reader.NextResult();

                while (reader.Read())
                {
                    var PartPicMappingObj = new SafetyMapping();
                    PartPicMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    PartPicMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    PartPicMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    PartPicMappingObj.Stage = reader["stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["stage"]);
                    PartPicMappingObj.SafetyDescription = reader["SafetyDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SafetyDescription"]);
                    PartPicMappingObj.SafetyPic = reader["SafetyPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SafetyPic"]);
                    PartPicMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    PartPicMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    PartPicMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    PartPicMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    PartPicMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    PartPicMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (PartPicMappingObj.SafetyPic != "")
                    {
                        PartPicMappingObj.SafetyPicPath = Path.Combine(BaseUrl, "Resources", "Images", "SafetyPicture", PartPicMappingObj.SafetyPic);
                    }
                    result.Data.Add(PartPicMappingObj);
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

        public Result<SafetyMapping> GetBySafetyId(int Id, string Connectionstring, string BaseUrl)
        {
            var result = new Result<SafetyMapping>
            {
                Status = true,
                Message = default(string),
                Data = new SafetyMapping()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByDelIdSafetyMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var PartPicMappingObj = new SafetyMapping();

                    PartPicMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    PartPicMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    PartPicMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    PartPicMappingObj.Stage = reader["stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["stage"]);
                    PartPicMappingObj.SafetyDescription = reader["SafetyDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SafetyDescription"]);
                    PartPicMappingObj.SafetyPic = reader["SafetyPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SafetyPic"]);
                    PartPicMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    PartPicMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    PartPicMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    PartPicMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    PartPicMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    if (PartPicMappingObj.SafetyPic != "")
                    {
                        PartPicMappingObj.SafetyPicPath = Path.Combine(BaseUrl, "Resources", "Images", "SafetyPicture", PartPicMappingObj.SafetyPic);
                    }

                    result.Data = PartPicMappingObj;

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

        public Result<int> GetSafetyInsertedDetails(Safety values, string Connectionstring)
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

                string rtn = "PRO_AddSafetyDetaiils";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("SafetyCategory", values.SafetyCategory);
                cmd.Parameters.AddWithValue("SafetyEquipment", values.SafetyEquipment);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", values.CreatedDate);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("IsDeleted", values.IsDeleted);

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
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return result;
        }

        public Result<int> AddorUpdateSafetyDetails(SafetyMapping values, string Connectionstring)
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
                string rtn = "PRO_AddorUpdateSafetyMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("Series", values.Series.Trim());
                cmd.Parameters.AddWithValue("MT", values.MT.Trim());
                cmd.Parameters.AddWithValue("Stage", values.Stage.Trim());
                cmd.Parameters.AddWithValue("SafetyDescription", values.SafetyDescription);
                cmd.Parameters.AddWithValue("SafetyPic", values.SafetyPic);
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


        public Result<int> DeleteSafetyDetails(SafetyMapping values, string Connectionstring)
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

                string rtn = "PRO_GetByDelIdSafetyMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeleteSafetyMapping");

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

