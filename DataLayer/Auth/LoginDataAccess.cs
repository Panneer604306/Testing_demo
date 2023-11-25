using BusinessModels;
using DataLayer.Contracts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DataLayer
{
    public class LoginDataAccess : ILoginDataAccess
    {
        public Result<Login> GetLoginDetails(string username, string password, string Connectionstring)
        {
            var result = new Result<Login>
            {
                Status = true,
                Message = default(string),
                Data = new Login()
            };
            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_CheckLogin";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("EmailId", username);
                cmd.Parameters.AddWithValue("Password", password);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Data.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    result.Data.FirstName = reader["FirstName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FirstName"]);
                    result.Data.LastName = reader["LastName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LastName"]);
                    result.Data.UserName = reader["UserName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UserName"]);
                    result.Data.EmailId = reader["EmailId"] == DBNull.Value ? string.Empty : Convert.ToString(reader["EmailId"]);
                    result.Data.Password = reader["Password"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Password"]);
                    result.Data.AuthToken = reader["AuthToken"] == DBNull.Value ? string.Empty : Convert.ToString(reader["AuthToken"]);
                    result.Data.RoleId = reader["RoleId"] == DBNull.Value ? string.Empty : Convert.ToString(reader["RoleId"]);
                    result.Data.MachineIP = reader["IPaddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["IPaddress"]);
                    result.Data.IsLineOperator = reader["IsLineOperator"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsLineOperator"]);
                }
                reader.NextResult();

                result.Data.ListRoleAccess = new List<ListRoleAccess>();
                while (reader.Read())
                {
                    ListRoleAccess RoleAccess = new ListRoleAccess();
                    RoleAccess.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    RoleAccess.ModuleId = reader["ModuleId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModuleId"]);
                    RoleAccess.ModuleName = reader["ModuleName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ModuleName"]);
                    RoleAccess.ModAdd = reader["Add"] == DBNull.Value ? false : Convert.ToBoolean(reader["Add"]);
                    RoleAccess.ModEdit = reader["Edit"] == DBNull.Value ? false : Convert.ToBoolean(reader["Edit"]);
                    RoleAccess.ModView = reader["View"] == DBNull.Value ? false : Convert.ToBoolean(reader["View"]);
                    RoleAccess.ModDelete = reader["Delete"] == DBNull.Value ? false : Convert.ToBoolean(reader["Delete"]);
                    result.Data.ListRoleAccess.Add(RoleAccess);
                }
                reader.NextResult();

                while (reader.Read())
                {
                    result.Status = Convert.ToBoolean(reader[0]);
                    result.Message = Convert.ToString(reader[1]);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message.ToString();
            }

            conn.Close();
            return result;
        }

        public Result<int> UpdateUserAuthtoken(string Authtoken, string username, string Connectionstring)
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

                string rtn = "PRO_UpdateUserLoginToken";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Authtoken", Authtoken);
                cmd.Parameters.AddWithValue("@EmailId", username);

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

        public Result<Login> ForgetPassword(string EmailId, string Connectionstring)
        {
            var result = new Result<Login>
            {
                Status = true,
                Message = default(string),
                Data = new Login()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetForgetPassword";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Email", EmailId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result.Data.FirstName = reader["FirstName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["FirstName"]);
                    result.Data.LastName = reader["LastName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["LastName"]);
                    result.Data.EmailId = reader["EmailId"] == DBNull.Value ? string.Empty : Convert.ToString(reader["EmailId"]);
                    result.Data.Password = reader["Password"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Password"]);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return result;
        }


    }
}
