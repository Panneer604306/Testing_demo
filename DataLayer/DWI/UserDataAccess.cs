using BusinessModels;
using BusinessModels.DWI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace DataLayer.DWI
{
    public class UserDataAccess
    {

        public CollectionResult<User> GetAllUser(string Connectionstring, string BaseUrl)
        {

            var result = new CollectionResult<User>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<User>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllUser";
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
                    var UserObj = new User();
                    UserObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    UserObj.FirstName = reader["FirstName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FirstName"]);
                    UserObj.LastName = reader["LastName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LastName"]);
                    UserObj.Role = reader["Role"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Role"]);
                    UserObj.Department = reader["Department"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Department"]);
                    UserObj.UserName = reader["UserName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UserName"]);
                    UserObj.Password = reader["Password"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Password"]);
                    UserObj.EmployeeId = reader["EmployeeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["EmployeeId"]);
                    UserObj.EmailId = reader["EmailId"] == DBNull.Value ? string.Empty : Convert.ToString(reader["EmailId"]);
                    UserObj.IPAddress = reader["IPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["IPAddress"]);
                    UserObj.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
                    UserObj.IsLineOperator = reader["IsLineOperator"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsLineOperator"]);
                    UserObj.IsADAccount = reader["IsADAccount"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsADAccount"]);
                    UserObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    UserObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    UserObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    UserObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    UserObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    UserObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    result.Data.Add(UserObj);
                    result.Message = "Get Users list Successfully";

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

        public CollectionResult<User> GetAllUserDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
              var result = new CollectionResult<User>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<User>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingUser";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PageIndex", pageIndex);
                cmd.Parameters.AddWithValue("PageSize", pageSize);
                cmd.Parameters.AddWithValue("Search", search);

                MySqlDataReader reader = cmd.ExecuteReader();
                reader.NextResult();

                while (reader.Read())
                {
                    var UserObj = new User();
                    UserObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    UserObj.FirstName = reader["FirstName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FirstName"]);
                    UserObj.LastName = reader["LastName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LastName"]);
                    UserObj.Role = reader["Role"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Role"]);
                    UserObj.Department = reader["Department"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Department"]);
                    UserObj.UserName = reader["UserName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UserName"]);
                    UserObj.Password = reader["Password"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Password"]);
                    UserObj.EmployeeId = reader["EmployeeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["EmployeeId"]);
                    UserObj.EmailId = reader["EmailId"] == DBNull.Value ? string.Empty : Convert.ToString(reader["EmailId"]);
                    UserObj.IPAddress = reader["IPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["IPAddress"]);
                    UserObj.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
                    UserObj.IsLineOperator = reader["IsLineOperator"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsLineOperator"]);
                    UserObj.IsADAccount = reader["IsADAccount"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsADAccount"]);
                    UserObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    UserObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    UserObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    UserObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    UserObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    UserObj.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);
                    result.Data.Add(UserObj);
                    result.Message = "Get Users list Successfully";
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

        public Result<User> GetByUserId(int Id, string Connectionstring)
        {
            var result = new Result<User>
            {
                Status = true,
                Message = default(string),
                Data = new User()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelUser";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var UserObj = new User();
                    UserObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    UserObj.FirstName = reader["FirstName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FirstName"]);
                    UserObj.LastName = reader["LastName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LastName"]);
                    UserObj.Role = reader["Role"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Role"]);
                    UserObj.Department = reader["Department"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Department"]);
                    UserObj.UserName = reader["UserName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UserName"]);
                    UserObj.Password = reader["Password"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Password"]);
                    UserObj.EmployeeId = reader["EmployeeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["EmployeeId"]);
                    UserObj.EmailId = reader["EmailId"] == DBNull.Value ? string.Empty : Convert.ToString(reader["EmailId"]);
                    UserObj.IPAddress = reader["IPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["IPAddress"]);
                    UserObj.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
                    UserObj.IsLineOperator = reader["IsLineOperator"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsLineOperator"]);
                    UserObj.IsADAccount = reader["IsADAccount"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsADAccount"]);
                    UserObj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    UserObj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    UserObj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    UserObj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    UserObj.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    result.Data = UserObj;

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

        public Result<int> AddorUpdateUser(User values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateUser";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("FirstName", values.FirstName);
                cmd.Parameters.AddWithValue("LastName", values.LastName);
                cmd.Parameters.AddWithValue("Role", values.Role);
                cmd.Parameters.AddWithValue("Department", values.Department);
                cmd.Parameters.AddWithValue("UserName", values.UserName);
                cmd.Parameters.AddWithValue("Password", values.Password);
                cmd.Parameters.AddWithValue("EmployeeId", values.EmployeeId);
                cmd.Parameters.AddWithValue("EmailId", values.EmailId);
                cmd.Parameters.AddWithValue("IPAddress", values.IPAddress);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("IsActive", values.IsActive);
                cmd.Parameters.AddWithValue("IsLineOperator", values.IsLineOperator);
                cmd.Parameters.AddWithValue("IsADAccount", values.IsADAccount);
                cmd.Parameters.AddWithValue("CreatedDate", values.CreatedDate);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("IsDeleted", values.IsDeleted);
                cmd.Parameters.AddWithValue("Mode", values.Mode);

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Data = Convert.ToInt32(rdr[0]);
                    result.Message = Convert.ToString(rdr[1]);
                    result.TotalCount = Convert.ToInt32(rdr[2]);
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

        public Result<int> DeleteUser(User values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelUser";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("ModifiedDate", values.ModifiedDate);
                cmd.Parameters.AddWithValue("Mode", "DeleteUserRecord");

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
