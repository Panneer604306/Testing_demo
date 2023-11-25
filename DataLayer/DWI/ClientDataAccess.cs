using BusinessModels;
using BusinessModels.DWI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DataLayer.DWI
{
    public class ClientDataAccess
    {
        #region public CollectionResult<GetStageList> GetStageList(string Connectionstring)
        public CollectionResult<GetStageList> GetStageList(string Connectionstring)
        {
            var result = new CollectionResult<GetStageList>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetStageList>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_DC_GetClientStageList";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var ClientObj = new GetStageList();
                    ClientObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    ClientObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    result.Data.Add(ClientObj);
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

        #region public CollectionResult<GetStageList> GetClientDisplay(string Connectionstring)
        public CollectionResult<GetClientDisplay> GetClientDisplay(string Connectionstring)
        {
            var result = new CollectionResult<GetClientDisplay>()
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetClientDisplay>()
            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_DC_GetClientDisplayList";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var ClientObj = new GetClientDisplay();
                    ClientObj.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    ClientObj.ClientDisplay = reader["ClientDisplay"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ClientDisplay"]);
                    ClientObj.Line = reader["Line"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Line"]);
                    ClientObj.Type = reader["Type"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Type"]);
                    result.Data.Add(ClientObj);
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

        #region public Result<Client> GetManualByClient(string MT, string Connectionstring, string BaseUrl)
        public Result<Client> GetManualByClient(string MT, string Connectionstring, string BaseUrl)
        {
            var result = new Result<Client>
            {
                Status = true,
                Message = default(string),
                Data = new Client()

            };

            string connStr = Connectionstring;
            //string Mode = "GetAllInfo";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_DC_GetClientByMT";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("MT", MT);

                getmyaddress();

                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    var ClientObj = new Client();
                    ClientObj.MT = reader["MT"] == DBNull.Value ? string.Empty : Convert.ToString(reader["MT"]);
                    ClientObj.Product = reader["Product"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Product"]);
                    ClientObj.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    ClientObj.Tiny = reader["Tiny"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Tiny"]);
                    ClientObj.Display = reader["Display"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Display"]);
                    ClientObj.Line = reader["Line"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Line"]);
                    ClientObj.Stage = reader["Stage"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Stage"]);
                    result.Data = ClientObj;

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

        #region public Result<Client> GetLiveByClient(string MT, string Connectionstring, string BaseUrl)
        public Result<Client> GetLiveByClient(string MT, string Tiny, string Display, string Connectionstring, string BaseUrl)
        {
            var result = new Result<Client>
            {
                Status = true,
                Message = default(string),
                Data = new Client()

            };

            string connStr = Connectionstring;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string rtn = "PRO_DC_GetLiveByClient";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("MT", MT);
                cmd.Parameters.AddWithValue("Tiny", Tiny);
                cmd.Parameters.AddWithValue("Display", Display);

                //getmyaddress();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Data.Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Id"]);
                    result.Data.Series = reader["Series"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Series"]);
                    result.Data.Product = reader["Product"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Product"]);
                }
                reader.NextResult();

                result.Data.ListByVideo = new List<GetByClientVideo>();
                while (reader.Read())
                {
                    var objGetByClientVideo = new GetByClientVideo();
                    objGetByClientVideo.Video = reader["Video"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Video"]);
                    objGetByClientVideo.Sequence = reader["Sequence"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Sequence"]);
                    if (objGetByClientVideo.Video != "")
                    {
                        objGetByClientVideo.VideoPath = Path.Combine(BaseUrl + "Resources\\Videos", objGetByClientVideo.Video);

                    }
                    result.Data.ListByVideo.Add(objGetByClientVideo);
                }
                reader.NextResult();

                result.Data.ListByPart = new List<GetByClientPart>();
                while (reader.Read())
                {
                    var objGetByClientPart = new GetByClientPart();
                    objGetByClientPart.ItemCode = reader["ItemCode"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemCode"]);
                    objGetByClientPart.ItemDescription = reader["ItemDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["ItemDescription"]);
                    objGetByClientPart.PartPic = reader["PartPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["PartPic"]);
                    if (objGetByClientPart.PartPic != "")
                    {
                        objGetByClientPart.PartPicPath = Path.Combine(BaseUrl + "Resources\\Images\\PartPicture", objGetByClientPart.PartPic);
                    }
                    result.Data.ListByPart.Add(objGetByClientPart);
                }
                reader.NextResult();

                result.Data.ListByTorque = new List<GetByClientTorque>();
                while (reader.Read())
                {
                    var objGetByClientTorque = new GetByClientTorque();
                    objGetByClientTorque.Torque = reader["Torque"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Torque"]);
                    objGetByClientTorque.TorquePic = reader["TorquePic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["TorquePic"]);
                    if (objGetByClientTorque.TorquePic != "")
                    {
                        objGetByClientTorque.TorquePicPath = Path.Combine(BaseUrl + "Resources\\Images\\TorquePicture", objGetByClientTorque.TorquePic);
                    }
                    result.Data.ListByTorque.Add(objGetByClientTorque);
                }
                reader.NextResult();

                result.Data.ListBySafety = new List<GetByClientSafety>();
                while (reader.Read())
                {
                    var objGetByClientSafety = new GetByClientSafety();
                    objGetByClientSafety.SafetyDescription = reader["SafetyDescription"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SafetyDescription"]);
                    objGetByClientSafety.SafetyPic = reader["SafetyPic"] == DBNull.Value ? string.Empty : Convert.ToString(reader["SafetyPic"]);
                    if (objGetByClientSafety.SafetyPic != "")
                    {
                        objGetByClientSafety.SafetyPicPath = Path.Combine(BaseUrl + "Resources\\Images\\SafetyPicture", objGetByClientSafety.SafetyPic);
                    }
                    result.Data.ListBySafety.Add(objGetByClientSafety);
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

        private string getmyaddress()
        {
            try
            {
                string hostName = Dns.GetHostName();
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                return myIP;
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}