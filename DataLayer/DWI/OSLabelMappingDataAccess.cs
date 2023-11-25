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
    public class OSLabelMappingDataAccess
    {
        public CollectionResult<OSLabelMapping> GetAllOSLabelMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<OSLabelMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<OSLabelMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllOSLabelMapping";
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
                    var OSLabelMappingObj = new OSLabelMapping();
                    OSLabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    OSLabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    OSLabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    OSLabelMappingObj.OSLabelType = reader["OSLabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OSLabelType"]);
                    OSLabelMappingObj.OSLabelPic = reader["OSLabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OSLabelPic"]);
                    OSLabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    OSLabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    OSLabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    OSLabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    OSLabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    OSLabelMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (OSLabelMappingObj.OSLabelPicPath != "")
                    {
                        OSLabelMappingObj.OSLabelPicPath = Path.Combine(BaseUrl, "Resources", "Images", "OSLabelPicture", OSLabelMappingObj.OSLabelPic);
                    }

                    result.Data.Add(OSLabelMappingObj);
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

        public CollectionResult<OSLabelMapping> GetAllOSLabelMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {
            //var result = new Result<Part>
            //{
            //    Status = true,
            //    Message = default(string),
            //    Data = new Part()

            //};
            var result = new CollectionResult<OSLabelMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<OSLabelMapping>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingOSLabelMapping";
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
                    var OSLabelMappingObj = new OSLabelMapping();
                    OSLabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    OSLabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    OSLabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    OSLabelMappingObj.OSLabelType = reader["OSLabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OSLabelType"]);
                    OSLabelMappingObj.OSLabelPic = reader["OSLabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OSLabelPic"]);
                    OSLabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    OSLabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    OSLabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    OSLabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    OSLabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    OSLabelMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (OSLabelMappingObj.OSLabelPicPath != "")
                    {
                        OSLabelMappingObj.OSLabelPicPath = Path.Combine(BaseUrl, "Resources", "Images", "OSLabelPicture", OSLabelMappingObj.OSLabelPic);
                    }

                    result.Data.Add(OSLabelMappingObj);
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

        public Result<OSLabelMapping> GetByOSLabelMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var result = new Result<OSLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new OSLabelMapping()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelOSLabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var OSLabelMappingObj = new OSLabelMapping();
                    OSLabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    OSLabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    OSLabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    OSLabelMappingObj.OSLabelType = reader["OSLabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OSLabelType"]);
                    OSLabelMappingObj.OSLabelPic = reader["OSLabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["OSLabelPic"]);
                    OSLabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    OSLabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    OSLabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    OSLabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    OSLabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    if (OSLabelMappingObj.OSLabelPic != "")
                    {
                        OSLabelMappingObj.OSLabelPicPath = Path.Combine(BaseUrl, "Resources", "Images", "OSLabelPicture", OSLabelMappingObj.OSLabelPic);
                    }
                    result.Data = OSLabelMappingObj;

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

        public Result<int> AddorUpdateOSLabelMapping(OSLabelMapping values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateOSLabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ItemCode", values.ItemCode.Trim());
                cmd.Parameters.AddWithValue("ItemDescription", values.ItemDescription);
                cmd.Parameters.AddWithValue("OSLabelType", values.OSLabelType.Trim());
                cmd.Parameters.AddWithValue("OSLabelPic", values.OSLabelPic);
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

        public Result<int> DeleteOSLabelMapping(OSLabelMapping values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelOSLabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeleteOSLabelMapping");

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
