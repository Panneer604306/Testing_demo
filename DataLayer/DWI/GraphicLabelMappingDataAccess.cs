using BusinessModels;
using BusinessModels.DWI;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace DataLayer.DWI
{
    public class GraphicLabelMappingDataAccess
    {
        public CollectionResult<GraphicLabelMapping> GetAllGraphicLabelMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<GraphicLabelMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GraphicLabelMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllGraphicLabelMapping";
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
                    var graphicLabelMappingObj = new GraphicLabelMapping();
                    graphicLabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID"]);
                    graphicLabelMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    graphicLabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    graphicLabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    graphicLabelMappingObj.GraphicLabelType = reader["GraphicLabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["GraphicLabelType"]);
                    graphicLabelMappingObj.GraphicLabelPic = reader["GraphicLabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["GraphicLabelPic"]);
                    graphicLabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    graphicLabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    graphicLabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    graphicLabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    graphicLabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    if (graphicLabelMappingObj.GraphicLabelPic != "")
                    {
                        graphicLabelMappingObj.GraphicLabelPicPath = Path.Combine(BaseUrl, "Resources", "Images", "GraphicLabelPicture", graphicLabelMappingObj.GraphicLabelPic);
                    }

                    result.Data.Add(graphicLabelMappingObj);
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

        public CollectionResult<GraphicLabelMapping> GetAllGraphicLabelMappingDetails(int PageIndex, int PageSize, string search, string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<GraphicLabelMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GraphicLabelMapping>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingGraphicLabelMapping";
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
                    var graphicLabelMappingObj = new GraphicLabelMapping();
                    graphicLabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID"]);
                    graphicLabelMappingObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    graphicLabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    graphicLabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    graphicLabelMappingObj.GraphicLabelType = reader["GraphicLabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["GraphicLabelType"]);
                    graphicLabelMappingObj.GraphicLabelPic = reader["GraphicLabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["GraphicLabelPic"]);
                    graphicLabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    graphicLabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    graphicLabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    graphicLabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    graphicLabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    if (graphicLabelMappingObj.GraphicLabelPic != "")
                    {
                        graphicLabelMappingObj.GraphicLabelPicPath = Path.Combine(BaseUrl, "Resources", "Images", "GraphicLabelPicture", graphicLabelMappingObj.GraphicLabelPic);
                    }

                    result.Data.Add(graphicLabelMappingObj);
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

        public Result<GraphicLabelMapping> GetByGraphicLabelMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var result = new Result<GraphicLabelMapping>
            {
                Status = true,
                Message = default(string),
                Data = new GraphicLabelMapping()

            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelGraphicLabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var graphicLabelMappingObj = new GraphicLabelMapping();
                    graphicLabelMappingObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ID"]);
                    graphicLabelMappingObj.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    graphicLabelMappingObj.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    graphicLabelMappingObj.GraphicLabelType = reader["GraphicLabelType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["GraphicLabelType"]);
                    graphicLabelMappingObj.GraphicLabelPic = reader["GraphicLabelPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["GraphicLabelPic"]);
                    graphicLabelMappingObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    graphicLabelMappingObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    graphicLabelMappingObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    graphicLabelMappingObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    graphicLabelMappingObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);

                    if (graphicLabelMappingObj.GraphicLabelPic != "")
                    {
                        graphicLabelMappingObj.GraphicLabelPicPath = Path.Combine(BaseUrl, "Resources", "Images", "GraphicLabelPicture", graphicLabelMappingObj.GraphicLabelPic);
                    }
                    result.Data = graphicLabelMappingObj;

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

        public Result<int> AddorUpdateGraphicLabelMapping(GraphicLabelMapping values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateGraphicLabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ItemCode", values.ItemCode.Trim());
                cmd.Parameters.AddWithValue("ItemDescription", values.ItemDescription);
                cmd.Parameters.AddWithValue("GraphicLabelType", values.GraphicLabelType.Trim());
                cmd.Parameters.AddWithValue("GraphicLabelPic", values.GraphicLabelPic);
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

        public Result<int> DeleteGraphicLabelMapping(GraphicLabelMapping values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelGraphicLabelMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "DeleteGraphicLabelMapping");
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
