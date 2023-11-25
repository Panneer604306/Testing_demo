using BusinessModels;
using BusinessModels.DWI;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace DataLayer.DWI
{
    public class CPULabelMappingDataAccess
    {

        public CollectionResult<CPULabelMapping> GetAllCPULabelMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<CPULabelMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<CPULabelMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllCPULabelMapping";
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
                    var CPULabelMappingObj = new CPULabelMapping();
                    CPULabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    CPULabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    CPULabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    CPULabelMappingObj.CPULabelType = reader["CPULabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["CPULabelType"]);
                    CPULabelMappingObj.CPULabelPic = reader["CPULabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["CPULabelPic"]);
                    CPULabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    CPULabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    CPULabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    CPULabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    CPULabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    CPULabelMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);

                    if (CPULabelMappingObj.CPULabelPic != "")
                    {
                        CPULabelMappingObj.CPULabelPicPath = Path.Combine(BaseUrl , "Resources", "Images", "CPULabelPicture", CPULabelMappingObj.CPULabelPic);
                    }

                    result.Data.Add(CPULabelMappingObj);
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

        public CollectionResult<CPULabelMapping> GetAllCPULabelMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {
            //var result = new Result<Part>
            //{
            //    Status = true,
            //    Message = default(string),
            //    Data = new Part()

            //};
            var result = new CollectionResult<CPULabelMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<CPULabelMapping>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingCPULabelMapping";
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
                    var CPULabelMappingObj = new CPULabelMapping();
                    CPULabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    CPULabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    CPULabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    CPULabelMappingObj.CPULabelType = reader["CPULabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["CPULabelType"]);
                    CPULabelMappingObj.CPULabelPic = reader["CPULabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["CPULabelPic"]);
                    CPULabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    CPULabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    CPULabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    CPULabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    CPULabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    CPULabelMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);

                    if (CPULabelMappingObj.CPULabelPic != "")
                    {
                        CPULabelMappingObj.CPULabelPicPath = Path.Combine(BaseUrl, "Resources", "Images", "CPULabelPicture", CPULabelMappingObj.CPULabelPic);
                    }

                    result.Data.Add(CPULabelMappingObj);
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

        public Result<CPULabelMapping> GetByCPULabelMappingId(int CPULabelMappingId, string Connectionstring, string BaseUrl)
        {
            var result = new Result<CPULabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new CPULabelMapping()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelCPULabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", CPULabelMappingId);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var CPULabelMappingObj = new CPULabelMapping();
                    CPULabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    CPULabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    CPULabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    CPULabelMappingObj.CPULabelType = reader["CPULabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["CPULabelType"]);
                    CPULabelMappingObj.CPULabelPic = reader["CPULabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["CPULabelPic"]);
                    CPULabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    CPULabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    CPULabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    CPULabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    CPULabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);

                    if (CPULabelMappingObj.CPULabelPic != "")
                    {
                        CPULabelMappingObj.CPULabelPicPath = Path.Combine(BaseUrl + "Resources\\Images\\CPULabelPicture", CPULabelMappingObj.CPULabelPic);
                    }

                    result.Data = CPULabelMappingObj;

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

        public Result<int> AddorUpdateCPULabelMapping(CPULabelMapping values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateCPULabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ItemCode", values.ItemCode.Trim());
                cmd.Parameters.AddWithValue("ItemDescription", values.ItemDescription);
                cmd.Parameters.AddWithValue("CPULabelType", values.CPULabelType.Trim());
                cmd.Parameters.AddWithValue("CPULabelPic", values.CPULabelPic);
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

        public Result<int> DeleteCPULabelMapping(CPULabelMapping values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelCPULabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("@ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("@ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeleteCPULabelMapping");

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
