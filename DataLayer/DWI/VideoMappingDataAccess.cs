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
    public class VideoMappingDataAccess
    {
        #region public CollectionResult<VideoMapping> GetAllVideoMapping(string Connectionstring, string BaseUrl)
        public CollectionResult<VideoMapping> GetAllVideoMapping(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<VideoMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<VideoMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllVideoMapping";
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
                    var Videomappingobj = new VideoMapping();
                    Videomappingobj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    Videomappingobj.Series = reader["series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["series"]);
                    Videomappingobj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    Videomappingobj.Tiny = reader["Tiny"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Tiny"]);
                    Videomappingobj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    Videomappingobj.Video = reader["Video"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Video"]);
                    Videomappingobj.Sequence = reader["Sequence"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Sequence"]);
                    Videomappingobj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    Videomappingobj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    Videomappingobj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    Videomappingobj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    Videomappingobj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    Videomappingobj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (Videomappingobj.Video != "" && Videomappingobj.Video != null)
                    {
                        Videomappingobj.VideoPath = Path.Combine(BaseUrl, "Resources", "Videos", Videomappingobj.Video);
                    }
                    result.Data.Add(Videomappingobj);
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
        #endregion

        #region public CollectionResult<VideoMapping> GetAllVideoMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        public CollectionResult<VideoMapping> GetAllVideoMappingDetails(int pageIndex, int pageSize, string search, string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<VideoMapping>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<VideoMapping>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingVideoMapping";
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
                    var Videomappingobj = new VideoMapping();
                    Videomappingobj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    Videomappingobj.Series = reader["series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["series"]);
                    Videomappingobj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    Videomappingobj.Tiny = reader["Tiny"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Tiny"]);
                    Videomappingobj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    Videomappingobj.Video = reader["Video"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Video"]);
                    Videomappingobj.Sequence = reader["Sequence"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Sequence"]);
                    Videomappingobj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    Videomappingobj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    Videomappingobj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    Videomappingobj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    Videomappingobj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    Videomappingobj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    if (Videomappingobj.Video != "" && Videomappingobj.Video != null)
                    {
                        Videomappingobj.VideoPath = Path.Combine(BaseUrl, "Resources", "Videos", Videomappingobj.Video);
                    }
                    result.Data.Add(Videomappingobj);
                    result.Message = "Selected Succesfully";

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

        #region public Result<VideoMapping> GetByVideoMappingId(int Id, string Connectionstring, string BaseUrl)
        public Result<VideoMapping> GetByVideoMappingId(int Id, string Connectionstring, string BaseUrl)
        {
            var result = new Result<VideoMapping>
            {
                Status = true,
                Message = default(string),
                Data = new VideoMapping()

            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelVideoMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var Videomappingobj = new VideoMapping();
                    Videomappingobj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    Videomappingobj.Series = reader["series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["series"]);
                    Videomappingobj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    Videomappingobj.Tiny = reader["Tiny"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Tiny"]);
                    Videomappingobj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    Videomappingobj.Video = reader["Video"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Video"]);
                    Videomappingobj.Sequence = reader["Sequence"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Sequence"]);
                    Videomappingobj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    Videomappingobj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    Videomappingobj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    Videomappingobj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    Videomappingobj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    if (Videomappingobj.Video != "" && Videomappingobj.Video != null)
                    {
                        Videomappingobj.VideoPath = Path.Combine(BaseUrl, "Resources", "Videos", Videomappingobj.Video);
                    }
                    result.Data = Videomappingobj;
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
        #endregion

        #region public Result<int> GetVideoMappingDetails(VideoMapping values,string Connectionstring)
        public Result<int> AddorUpdateVideoMapping(VideoMapping values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateVideoMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("MT", values.MT.Trim());
                cmd.Parameters.AddWithValue("Series", values.Series.Trim());
                cmd.Parameters.AddWithValue("Tiny", values.Tiny.Trim());
                cmd.Parameters.AddWithValue("Display", values.Display.Trim());
                cmd.Parameters.AddWithValue("Video", values.Video);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedDate", values.CreatedDate);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", values.Mode.Trim());
                cmd.Parameters.AddWithValue("Sequence", values.Sequence);
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

        #region public Result<int> DeleteVideoMapping(VideoMapping values, string Connectionstring)
        public Result<int> DeleteVideoMapping(VideoMapping values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelVideoMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeleteVideoMapping");

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Data = Convert.ToInt32(rdr[0]);
                    result.Message = Convert.ToString(rdr[1]);
                    result.Message = "Deleted Successfully";
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
