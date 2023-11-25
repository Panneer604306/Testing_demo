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
    public class RoleDataAccess
    {
        #region public CollectionResult<Role> GetAllRoleDetails(string Connectionstring)
        public CollectionResult<Role> GetAllRoleDetails(int pageIndex, int pageSize, string search, string Connectionstring)
        {
            var result = new CollectionResult<Role>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<Role>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_PagingRole";
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
                    var objRole = new Role();
                    objRole.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    objRole.Roles = reader["Role"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Role"]);
                    objRole.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    objRole.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    objRole.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    objRole.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    objRole.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    objRole.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);
                    objRole.RowNumber = reader["RowNumber"] == DBNull.Value ? 0 : Convert.ToInt32(reader["RowNumber"]);

                    result.Data.Add(objRole);
                    result.Message = "Get Role List Successfully";

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

        #region public Result<Role> GetByRoleId(int RoleId, string Connectionstring)
        public Result<Role> GetByRoleId(int RoleId, string Connectionstring)
        {
            var result = new Result<Role>
            {
                Status = true,
                Message = default(string),
                Data = new Role()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByIdDelRole";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("RoleId", RoleId);
                cmd.Parameters.AddWithValue("ModifiedBy", 0);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("Mode", "GetById");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var objRole = new Role();
                    objRole.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    objRole.Roles = reader["Role"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Role"]);
                    objRole.CreatedBy = reader["CreatedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["CreatedBy"]);
                    objRole.CreatedDate = reader["CreatedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["CreatedDate"]);
                    objRole.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModifiedBy"]);
                    objRole.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(reader["ModifiedDate"]);
                    objRole.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    objRole.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                    
                    result.Data = objRole;

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

        #region public Result<UserPermissions> GetByRoleIdAccess(string RoleName, string Connectionstring)
        public Result<UserPermissions> GetByRoleIdAccess(int Id, string Connectionstring)
        {
            var result = new Result<UserPermissions>
            {
                Status = true,
                Message = default(string),
                Data = new UserPermissions()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetByRoleIdAccess";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", Id);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Data.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    result.Data.Role = reader["Role"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Role"]);
                    result.Data.IsActive = reader["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsActive"]);

                }
                reader.NextResult();

                result.Data.ObjLstUserModule = new List<UserModulePermission>();

                while (reader.Read())
                {
                    var ObjUserModulePermission = new UserModulePermission();
                    ObjUserModulePermission.ModuleId = reader["ModuleId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ModuleId"]);
                    ObjUserModulePermission.ModuleName = reader["ModuleName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ModuleName"]);
                    ObjUserModulePermission.ModuleType = reader["ModuleType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ModuleType"]);
                    ObjUserModulePermission.ModAdd = reader["Add"] == DBNull.Value ? false : Convert.ToBoolean(reader["Add"]);
                    ObjUserModulePermission.ModEdit = reader["Edit"] == DBNull.Value ? false : Convert.ToBoolean(reader["Edit"]);
                    ObjUserModulePermission.ModView = reader["View"] == DBNull.Value ? false : Convert.ToBoolean(reader["View"]);
                    ObjUserModulePermission.ModDelete = reader["Delete"] == DBNull.Value ? false : Convert.ToBoolean(reader["Delete"]);
                    result.Data.ObjLstUserModule.Add(ObjUserModulePermission);
                    result.Message = "Get Role Access List Successfully";
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

        #region public Result<int> AddorUpdateByRole(UserPermissions values, string Connectionstring)
        public Result<int> AddorUpdateByRole(UserPermissions values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateRoleDetails";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", values.Id);
                cmd.Parameters.AddWithValue("RoleName", values.Role);
                cmd.Parameters.AddWithValue("CreatedBy", values.CreatedBy);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("IsActive", values.IsActive);
                cmd.Parameters.AddWithValue("Mode", values.Mode);

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Status = Convert.ToBoolean(rdr[0]);
                    result.Message = Convert.ToString(rdr[1]);
                    result.Data = Convert.ToInt32(rdr[2]);
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

        #region public Result<int> UserModulePermission(int RoleId, UserPermissions value, UserModulePermission values, string Connectionstring)
        public Result<int> UserModulePermission(int RoleId, UserPermissions value, UserModulePermission values, string Connectionstring)
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

                string rtn = "PRO_AddorUpdateRoleAccess";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("RoleId", RoleId);
                cmd.Parameters.AddWithValue("RoleName", value.Role.ToUpper());
                cmd.Parameters.AddWithValue("CreatedBy", value.CreatedBy);
                cmd.Parameters.AddWithValue("ModifiedBy", value.ModifiedBy);
                cmd.Parameters.AddWithValue("ModuleId", values.ModuleId);
                cmd.Parameters.AddWithValue("ModuleName", values.ModuleName);
                cmd.Parameters.AddWithValue("ModuleType", values.ModuleType);
                cmd.Parameters.AddWithValue("ModAdd", values.ModAdd);
                cmd.Parameters.AddWithValue("ModEdit", values.ModEdit);
                cmd.Parameters.AddWithValue("ModView", values.ModView);
                cmd.Parameters.AddWithValue("ModDelete", values.ModDelete); 
                cmd.Parameters.AddWithValue("Mode", value.Mode);

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

        #region public Result<int> DeleteRoleById(Role values, string Connectionstring)
        public Result<int> DeleteRoleById(Role values, string Connectionstring)
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

                string rtn = "PRO_GetByIdDelRole";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("RoleId", values.Id);
                cmd.Parameters.AddWithValue("ModifiedBy", values.ModifiedBy);
                cmd.Parameters.AddWithValue("Mode", "DeleteRole");

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Status = Convert.ToBoolean(rdr[0]);
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
