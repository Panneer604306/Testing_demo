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
    public class PartPicMappingDataAccess
    {
        public CollectionResult<PartPicMapping> GetAllPartPicMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<PartPicMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<PartPicMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllPartPicMapping";
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
                    var PartPicMappingObj = new PartPicMapping();
                    PartPicMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    PartPicMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    PartPicMappingObj.MTM = reader["MTM"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MTM"]);
                    PartPicMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    PartPicMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    PartPicMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    PartPicMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    PartPicMappingObj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    PartPicMappingObj.PartPic = reader["PartPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PartPic"]);
                    PartPicMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    PartPicMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    PartPicMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    PartPicMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    PartPicMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    PartPicMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (PartPicMappingObj.PartPic != "")
                    {
                        PartPicMappingObj.PartPicPath = Path.Combine(BaseUrl + "Resources\\Images\\PartPicture", PartPicMappingObj.PartPic);
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

        public CollectionResult<PartPicMapping> GetAllPartPicMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {
            var result = new CollectionResult<PartPicMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<PartPicMapping>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingPartPicMapping";
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
                    var PartPicMappingObj = new PartPicMapping();
                    PartPicMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    PartPicMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    PartPicMappingObj.MTM = reader["MTM"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MTM"]);
                    PartPicMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    PartPicMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    PartPicMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    PartPicMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    PartPicMappingObj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    PartPicMappingObj.PartPic = reader["PartPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PartPic"]);
                    PartPicMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    PartPicMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    PartPicMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    PartPicMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    PartPicMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    PartPicMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (PartPicMappingObj.PartPic != "")
                    {
                        PartPicMappingObj.PartPicPath = Path.Combine(BaseUrl + "Resources\\Images\\PartPicture", PartPicMappingObj.PartPic);
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

        public Result<PartPicMapping> GetByPartPicMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var result = new Result<PartPicMapping>
            {
                Status = true,
                Message = default(string),
                Data = new PartPicMapping()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelPartPicMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var PartPicMappingObj = new PartPicMapping();

                    PartPicMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    PartPicMappingObj.MTM = reader["MTM"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MTM"]);
                    PartPicMappingObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    PartPicMappingObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    PartPicMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    PartPicMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    PartPicMappingObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    PartPicMappingObj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    PartPicMappingObj.PartPic = reader["PartPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PartPic"]);
                    PartPicMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    PartPicMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    PartPicMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    PartPicMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    PartPicMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    if (PartPicMappingObj.PartPic != "")
                    {
                        PartPicMappingObj.PartPicPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Images\\PartPicture", PartPicMappingObj.PartPic);
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

        public Result<int> AddorUpdatePartPicMapping(PartPicMapping values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdatePartPicMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("MT", values.MT);
                cmd.Parameters.AddWithValue("MTM", values.MTM);
                cmd.Parameters.AddWithValue("Series", values.Series);
                cmd.Parameters.AddWithValue("ItemCode", values.ItemCode);
                cmd.Parameters.AddWithValue("ItemDescription", values.ItemDescription);
                cmd.Parameters.AddWithValue("Stage", values.Stage);
                cmd.Parameters.AddWithValue("Display", values.Display);
                cmd.Parameters.AddWithValue("PartPic", values.PartPic);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", values.CreatedDate);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", values.Mode);

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

        public Result<int> DeletePartPicMapping(PartPicMapping values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelPartPicMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeletePartPicMapping");

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
