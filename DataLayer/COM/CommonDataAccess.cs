using BusinessModels;
using BusinessModels.COM;
using DataLayer.Contracts.COM;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DataLayer.COM
{
    public class CommonDataAccess : ICommonDataAccess
    {

        #region public Result<GetUserPermissions> GetByRoleIdAccess(int Id, string Connectionstring)
        public Result<GetUserPermissions> GetByRoleIdAccess(int Id, string Connectionstring)
        {
            var result = new Result<GetUserPermissions>
            {
                Status = true,
                Message = default(string),
                Data = new GetUserPermissions()

            };

            string connStr = Connectionstring;
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

                result.Data.ObjLstUserModule = new List<GetUserModulePermission>();

                while (reader.Read())
                {
                    var ObjUserModulePermission = new GetUserModulePermission();
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

        #region public CollectionResult<AllSeries> GetAllSeriesDetails(string Connectionstring)
        public CollectionResult<AllSeries> GetAllSeriesDetails(string Connectionstring)
        {
            var result = new CollectionResult<AllSeries>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<AllSeries>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetAllSeries";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var objSeries = new AllSeries();
                    objSeries.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    objSeries.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    objSeries.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    result.Data.Add(objSeries);
                    result.Message = "Get Series List Successfully";

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

        #region public Result<MTBySeries> GetMTBySeries(string Series, string Connectionstring, string BaseUrl)
        public Result<MTBySeries> GetMTBySeries(string Series, string Connectionstring, string BaseUrl)
        {
            var result = new Result<MTBySeries>
            {
                Status = true,
                Message = default(string),
                Data = new MTBySeries()

            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetMTBySeries";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Series", Series);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var objMTBySeries = new MTBySeries();
                    objMTBySeries.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    objMTBySeries.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    objMTBySeries.IsDeleted = reader["IsDeleted"] == DBNull.Value ? false : Convert.ToBoolean(reader["IsDeleted"]);
                    result.Data = objMTBySeries;
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

        #region public CollectionResult<ClienDisplaytList> GetClientDropDownList(string Connectionstring)
        public CollectionResult<ClienDisplaytList> GetClientDropDownList(string Connectionstring)
        {
            var result = new CollectionResult<ClienDisplaytList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<ClienDisplaytList>()
            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetClientDropDownList";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var Videomappingobj = new ClienDisplaytList();
                    Videomappingobj.Tiny = reader["Tiny"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Tiny"]);
                    Videomappingobj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    Videomappingobj.TinyDisplay = reader["TinyDisplay"] == DBNull.Value ? string.Empty : Convert.ToString(reader["TinyDisplay"]);
                    result.Data.Add(Videomappingobj);
                    result.Message = "Get Client DropDown List Successfully";
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

        #region public CollectionResult<GetRoles> GetDropDownRoles(string Connectionstring)
        public CollectionResult<GetRoles> GetDropDownRoles(string Connectionstring)
        {
            var result = new CollectionResult<GetRoles>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetRoles>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetCreateProfileRoles";
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
                    var objRole = new GetRoles();
                    objRole.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    objRole.Roles = reader["Role"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Role"]);
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

        #region public CollectionResult<GetAllSatge> GetAllStage(string Connectionstring)
        public CollectionResult<GetAllSatge> GetAllStage(string Connectionstring)
        {
            var result = new CollectionResult<GetAllSatge>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetAllSatge>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_GetStageMapping";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var objGetAllSatge = new GetAllSatge();
                    objGetAllSatge.IPAddress = reader["IPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["IPAddress"]);
                    objGetAllSatge.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    objGetAllSatge.ConfIPAddress = reader["ConfIPAddress"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfIPAddress"]);
                    objGetAllSatge.ConfStage = reader["ConfStage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ConfStage"]);
                    result.Data.Add(objGetAllSatge);
                    result.Message = "Get Stage List Successfully";
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

        #region public CollectionResult<CountStatus> GetAllCount(string Connectionstring, string mode)
        public Result<CountStatus> GetAllCount(string Connectionstring, string line)
        {
            var result = new Result<CountStatus>()
            {
                Status = true,
                Message = default(string),
                Data = new CountStatus()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetCounts";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("stage", line);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //var CPULabelMappingObj = new CountStatus();
                     result.Data.Total = reader["Total"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Total"]);
                     result.Data.Assembly = reader["Assembly"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Assembly"]);
                     result.Data.Debug = reader["Debug"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Debug"]);
                     result.Data.Packing = reader["Packing"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Packing"]);
                     result.Data.AssemblyFailure = reader["Assembly_Failure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Assembly_Failure"]);
                     result.Data.DebugFailure = reader["Debug_Failure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Debug_Failure"]);
                     result.Data.PackingFailure = reader["Packing_Failure"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Packing_Failure"]);
                     result.Data.AssemblySolution = reader["Assembly_Solution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Assembly_Solution"]);
                     result.Data.DebugSolution = reader["Debug_Solution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Debug_Solution"]);
                     result.Data.PackingSolution = reader["Packing_Solution"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Packing_Solution"]);
                     result.Data.Open = reader["Open"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Open"]);
                    result.Data.Close = reader["Close"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Close"]);
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
        #endregion

        #region public Result<GetRTYProductId> GetRTYProductByMT(string MT, string Connectionstring) 
        public Result<GetRTYProductId> GetRTYProductByMT(string MT, string Connectionstring)
        {
            var result = new Result<GetRTYProductId>
            {
                Status = true,
                Message = default(string),
                Data = new GetRTYProductId()

            };

            string connStr = Connectionstring;

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetProductByMT";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("MT", MT);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var ProdObj = new GetRTYProductId();
                    ProdObj.Product = reader["Product"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Product"]);
                    ProdObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    result.Data = ProdObj;
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

        #region public CollectionResult<GetPartList> GetPartList(string Connectionstring)
        public CollectionResult<GetPartList> GetPartList(string Connectionstring)
        {
            var result = new CollectionResult<GetPartList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetPartList>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetPartList";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var RTYPartObj = new GetPartList();
                    RTYPartObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    RTYPartObj.PartName = reader["PartName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PartName"]);
                    result.Data.Add(RTYPartObj);
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

        #region public CollectionResult<GetPartByProduct> GetPartByProduct(string Product, string Connectionstring)
        public CollectionResult<GetPartByProduct> GetPartByProduct(string Product, string Connectionstring)
        {
            var result = new CollectionResult<GetPartByProduct>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetPartByProduct>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetPartByProduct";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Product", Product);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var GetPartByProduct = new GetPartByProduct();
                    GetPartByProduct.Product = reader["Product"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Product"]);
                    GetPartByProduct.PartName = reader["PartName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PartName"]);
                    result.Data.Add(GetPartByProduct);
                    result.Message = "Get Prat Successfully";
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

        #region public CollectionResult<GetProblemClassList> GetByProblemClass(string ProblemType, string Connectionstring)
        public CollectionResult<GetProblemClassList> GetByProblemClass(string ProblemType, string Connectionstring)
        {
            var result = new CollectionResult<GetProblemClassList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetProblemClassList>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetPrbmTypeIdByPrbmCls";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProblemType", ProblemType);


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var GetProblemClassList = new GetProblemClassList();
                    GetProblemClassList.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    GetProblemClassList.ProblemType = reader["ProblemType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProblemType"]);
                    GetProblemClassList.ProblemCls = reader["ProblemClass"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProblemClass"]);
                    result.Data.Add(GetProblemClassList);
                    result.Message = "Get Problem Class Successfully";

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

        #region public Result<ProblemType> GetByProblemType(string PartName, string Connectionstring)
        public CollectionResult<GetProblemTypeList> GetByProblemType(string PartName, string Connectionstring)
        {
            var result = new CollectionResult<GetProblemTypeList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetProblemTypeList>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetPartNameByPrbmType";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PartName", PartName);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var GetProblemTypeList = new GetProblemTypeList();
                    GetProblemTypeList.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    GetProblemTypeList.ProblemTypes = reader["PartName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PartName"]);
                    GetProblemTypeList.ProblemTypes = reader["ProblemType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ProblemType"]);
                    result.Data.Add(GetProblemTypeList);
                    result.Message = "Get Problem Type Successfully";

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

        #region public Result<GetSolutionTypeList> GetBySolutionType(string PartName, string Connectionstring)
        public CollectionResult<GetSolutionTypeList> GetBySolutionType(string PartName, string Connectionstring)
        {
            var result = new CollectionResult<GetSolutionTypeList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetSolutionTypeList>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetPartNameBySolutionType";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("PartName", PartName);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var GetSolutionTypeList = new GetSolutionTypeList();
                    GetSolutionTypeList.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    GetSolutionTypeList.PartName = reader["PartName"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PartName"]);
                    GetSolutionTypeList.SolutionTypes = reader["SolutionType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SolutionType"]);
                    result.Data.Add(GetSolutionTypeList);
                    result.Message = "Get Solution Type Successfully";

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

        #region public CollectionResult<GetSolutionClassList> GetBySolutionClass(string SolutionType, string Connectionstring)
        public CollectionResult<GetSolutionClassList> GetBySolutionClass(string SolutionType, string Connectionstring)
        {
            var result = new CollectionResult<GetSolutionClassList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetSolutionClassList>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetSolTypeIdBySolutionCls";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("SolutionType", SolutionType);


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var GetSolutionClassList = new GetSolutionClassList();
                    GetSolutionClassList.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    GetSolutionClassList.SolutionType = reader["SolutionType"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SolutionType"]);
                    GetSolutionClassList.SolutionCls = reader["SolutionClass"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SolutionClass"]);
                    result.Data.Add(GetSolutionClassList);
                    result.Message = "Get Solution Class Successfully";

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


        #region public CollectionResult<GetSolutionClassList> GetByOwners(string SolutionType, string Connectionstring)
        public CollectionResult<GetOwnersList> GetByOwners(string UWIP, string Stage, string Connectionstring)
        {
            var result = new CollectionResult<GetOwnersList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetOwnersList>()
            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_RTY_GetOwners";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UWIP", UWIP);
                cmd.Parameters.AddWithValue("Stage", Stage);


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var solutionOwners = new GetOwnersList();
                    solutionOwners.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    solutionOwners.UWIP = reader["UWIP"] == DBNull.Value ? string.Empty : Convert.ToString(reader["UWIP"]);
                    solutionOwners.Rty_Status = reader["Rty_Status"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Rty_Status"]);
                    solutionOwners.Owners = reader["Owners"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Owners"]);
                    result.Data.Add(solutionOwners);
                    result.Message = "Get Solution Owners Successfully";

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
    }
}
