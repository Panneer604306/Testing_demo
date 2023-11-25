using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Contracts.DWI;
using BusinessLayer.DWI;
using BusinessModels;
using BusinessModels.DWI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DWI_Application.Controllers.DWI_API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IClientBusinessAccess _clientBusinessAccess;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ClientController(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _clientBusinessAccess = new ClientBusinessAccess();
            _hostingEnvironment = env;
        }

        #region public IActionResult GetStageList()
        //[HttpGet]
        //[Route("GetStageList")]
        //public IActionResult GetStageList()
        //{
        //    var responseData = new CollectionResult<GetStageList>
        //    {
        //        Status = true,
        //        Message = default(string),
        //        Data = new Collection<GetStageList>()
        //    };
        //    try
        //    {
        //        string Connectionstring = _configuration.GetConnectionString("Default");
        //        responseData = _clientBusinessAccess.GetStageList(Connectionstring);
        //        return new JsonResult(responseData);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
        #region public IActionResult GetStageList()
        [HttpGet]
        [Route("GetClientDisplay")]
        public IActionResult GetClientDisplay()
        {
            var responseData = new CollectionResult<GetClientDisplay>
            {
                Status = true,
                Message = default(string),
                Data = new Collection<GetClientDisplay>()
            };
            try
            {
                string Connectionstring = _configuration.GetConnectionString("Default");
                responseData = _clientBusinessAccess.GetClientDisplay(Connectionstring);
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetManualByClient(string MT)
        [HttpGet]
        [Route("GetManualByClient")]
        public IActionResult GetManualByClient(string MT)
        {
            var responseData = new Result<Client>
            {
                Status = true,
                Message = default(string),
                Data = new Client()

            };
            try
            {
                if (MT != null)
                {
                    string Connectionstring = _configuration.GetConnectionString("Default");
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    responseData = _clientBusinessAccess.GetManualByClient(MT, Connectionstring, BaseUrl);
                    return new JsonResult(responseData);
                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Invalid parameter value detected.!!!", Data = 0 });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region public IActionResult GetLiveByClient(string Tiny, string Display)
        [HttpGet]
        [Route("GetLiveByClient")]
        public IActionResult GetLiveByClient(string MT, string tinyDisplay)
        {
            var responseData = new Result<Client>
            {
                Status = true,
                Message = default(string),
                Data = new Client()

            };

            //string pathvalue = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "Resources", "Script");
            string pathvalue = _configuration.GetValue<string>("ReadSWSNotePad");
            if (MT == null)
            {
                //MT = "1S11DUL99021118009";
                MT = GetMTValue(pathvalue);
            }

            try
            {
                if (tinyDisplay != "")
                {
                    string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                    //Client result = new Client();
                    var res = NotePadData(MT, tinyDisplay);
                    if (res.Count > 0)
                    {
                        var result = res.FirstOrDefault();
                        List<GetByClientVideo> getByClientVideo = new List<GetByClientVideo>();
                        String[] Videoarray = result.Video == "" ? null : result.Video.Split(',');

                        if (Videoarray != null)
                        {
                            foreach (var item in Videoarray)
                            {
                                GetByClientVideo clientVideo = new GetByClientVideo();
                                clientVideo.Video = item.Trim();
                                clientVideo.VideoPath = Path.Combine(BaseUrl, "Resources", "Videos", item.Trim());
                                getByClientVideo.Add(clientVideo);
                            }
                        }

                        List<GetByClientPart> getByClientPart = new List<GetByClientPart>();
                        String[] partPicarray = result.PartPc == "" ? null : result.PartPc.Split(',');
                        String[] partNamearray = result.PartPicName == "" ? null : result.PartPicName.Split(',');

                        if (partPicarray != null && partNamearray != null)
                        {
                            foreach (var item in partPicarray)
                            {
                                GetByClientPart clientPart = new GetByClientPart();
                                foreach (var items in partNamearray)
                                {
                                    clientPart.ItemCode = items.Trim();
                                }

                                clientPart.PartPic = item.Trim();
                                clientPart.PartPicPath = Path.Combine(BaseUrl, "Resources", "Images", "PartPicture", item.Trim());
                                getByClientPart.Add(clientPart);
                            }
                        }

                        List<GetByClientTorque> GetByClientTorque = new List<GetByClientTorque>();
                        String[] torquePiccarray = result.Torque == "" ? null : result.Torque.Split(',');
                        String[] torqueNamearray = result.TorqueName == "" ? null : result.TorqueName.Split(',');

                        if (torquePiccarray != null && torqueNamearray != null)
                        {
                            foreach (var item in torquePiccarray)
                            {
                                GetByClientTorque clientTorque = new GetByClientTorque();
                                foreach (var items in torqueNamearray)
                                {
                                    clientTorque.Torque = items.Trim();
                                }

                                clientTorque.TorquePic = item.Trim();
                                clientTorque.TorquePicPath = Path.Combine(BaseUrl, "Resources", "Images", "TorquePicture", item.Trim());
                                GetByClientTorque.Add(clientTorque);
                            }
                        }

                        List<GetByClientSafety> getByClientSafety = new List<GetByClientSafety>();
                        String[] safetyPiccarray = result.Safety == "" ? null : result.Safety.Split(',');
                        String[] safetyNamearray = result.SafetyName == "" ? null : result.SafetyName.Split(',');

                        if (safetyPiccarray != null && safetyNamearray != null)
                        {
                            foreach (var item in safetyPiccarray)
                            {
                                GetByClientSafety clientSafety = new GetByClientSafety();
                                foreach (var items in safetyNamearray)
                                {
                                    clientSafety.SafetyDescription = items.Trim();
                                }

                                clientSafety.SafetyPic = item.Trim();
                                clientSafety.SafetyPicPath = Path.Combine(BaseUrl, "Resources", "Images", "SafetyPicture", item.Trim());
                                getByClientSafety.Add(clientSafety);
                            }
                        }

                        string noImg = Path.Combine(BaseUrl, "Resources", "Images", "NoImage.png");
                        var CPULabelPic = result.CPULabelPic.Trim() == "" ? noImg : Path.Combine(BaseUrl, "Resources", "Images", "CPULabelPicture", result.CPULabelPic.Trim());
                        var OSLabelPic = result.OSLabelPic.Trim() == "" ? noImg : Path.Combine(BaseUrl, "Resources", "Images", "OSLabelPicture", result.OSLabelPic.Trim());
                        var GraphicPic = result.GraphicPic.Trim() == "" ? noImg : Path.Combine(BaseUrl, "Resources", "Images", "GraphicLabelPicture", result.GraphicPic.Trim());
                        responseData.Data.Product = result.ProductName;
                        responseData.Data.Series = result.Series;
                        responseData.Data.MT = result.MT;
                        responseData.Data.MTM = result.MTM;
                        responseData.Data.Tiny = result.Tiny;
                        responseData.Data.Display = result.Display;
                        responseData.Data.Line = result.Line;
                        responseData.Data.ListByVideo = getByClientVideo;
                        responseData.Data.ListByPart = getByClientPart;
                        responseData.Data.ListByTorque = GetByClientTorque;
                        responseData.Data.ListBySafety = getByClientSafety;
                        responseData.Data.CPULabelPic = CPULabelPic;
                        responseData.Data.OSLabelPic = OSLabelPic;
                        responseData.Data.GraphicPic = GraphicPic;

                        //string Connectionstring = _configuration.GetConnectionString("Default");
                        //string BaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
                        //responseData = _clientBusinessAccess.GetLiveByClient(MT, Tiny, Display, Connectionstring, BaseUrl);

                        return new JsonResult(responseData);
                    }
                    else
                    {
                        return BadRequest(new { Status = false, Message = "Invalid parameter value detected.!!!", Data = 0 });
                    }

                }
                else
                {
                    return BadRequest(new { Status = false, Message = "Invalid parameter value detected.!!!", Data = 0 });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = false, Message = ex.Message.ToString(), Data = 0 });
            }
        }
        #endregion

        private string GetMTValue(string MTPath)
        {
            string mt = string.Empty;
            List<string> getNoteInput = new List<string>();
            try
            {
                using (System.IO.StreamReader sr = System.IO.File.OpenText(MTPath))
                {
                    String input;
                    while ((input = sr.ReadLine()) != null)
                    {
                        getNoteInput.Add(input);
                    }

                    foreach (string line in getNoteInput)
                    {
                        if (line.Split('=')[0].Trim() != "" && line.Split('=')[1].Trim() != "")
                        {
                            mt = line.Split('=')[1].Trim();
                        }
                    }
                    sr.Dispose();
                    //File.Create(MTPath).Dispose();
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return mt;
        }

        private List<NotePadData> NotePadData(string mt, string tinyDisplay)
        {
            string strtiny = tinyDisplay.Substring(0, 2);
            string strdisplay = tinyDisplay.Substring(2, 2);
            try
            {
                List<NotePadData> displaySplits = new List<NotePadData>();
                NotePadData objNotePadData = new NotePadData();
                var inputMt = CampareMT(mt, strtiny, strdisplay);
                string ScriptFile = _configuration.GetValue<string>("ReadNotePad");
                var CombinePath = Path.Combine(ScriptFile + strtiny + "\\" + inputMt + "\\" + strtiny + "_" + strdisplay + ".txt");
                bool dirExists = Directory.Exists(CombinePath);
                if (!System.IO.File.Exists(CombinePath))
                {
                    return displaySplits;
                }
                else
                {
                    try
                    {
                        if (dirExists == false)
                        {

                            List<string> piciAllLines = new List<string>();
                            if (CombinePath != null)
                            {
                                using (System.IO.StreamReader sr = System.IO.File.OpenText(CombinePath))
                                {
                                    String input;
                                    while ((input = sr.ReadLine()) != null)
                                    {
                                        piciAllLines.Add(input);
                                        Console.WriteLine(input);
                                    }
                                    sr.Close();
                                }

                            }

                            foreach (string line in piciAllLines)
                            {
                                if (line != null)
                                {
                                    if (line.Split(':')[0] == "ProductName")
                                    {
                                        objNotePadData.ProductName = line.Split(':')[1];
                                    }
                                    if (line.Split(':')[0] == "MT")
                                    {
                                        objNotePadData.MT = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Series")
                                    {
                                        objNotePadData.Series = line.Split(':')[1];
                                    }
                                    if (line.Split(':')[0] == "MTM")
                                    {
                                        objNotePadData.MTM = line.Split(':')[1];
                                    }
                                    if (line.Split(':')[0] == "Tiny")
                                    {
                                        objNotePadData.Tiny = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Display")
                                    {
                                        objNotePadData.Display = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Line")
                                    {
                                        objNotePadData.Line = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Video")
                                    {
                                        objNotePadData.Video = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Line_RTY")
                                    {
                                        objNotePadData.Line_RTY = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "PartPic")
                                    {
                                        objNotePadData.PartPc = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "PartPicName")
                                    {
                                        objNotePadData.PartPicName = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Assembly")
                                    {
                                        objNotePadData.Assembly = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "TestingFPY")
                                    {
                                        objNotePadData.Testing_FPY = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "PackingFPY")
                                    {
                                        objNotePadData.Packing_FPY = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Torque")
                                    {
                                        objNotePadData.Torque = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "TorqueName")
                                    {
                                        objNotePadData.TorqueName = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Safety")
                                    {
                                        objNotePadData.Safety = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "SafetyName")
                                    {
                                        objNotePadData.SafetyName = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "CPULabelPic")
                                    {
                                        objNotePadData.CPULabelPic = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "OSLabelPic")
                                    {
                                        objNotePadData.OSLabelPic = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "GraphicPic")
                                    {
                                        objNotePadData.GraphicPic = line.Split(':')[1].Trim();
                                    }
                                    if (line.Split(':')[0] == "Warning")
                                    {
                                        objNotePadData.Warning = line.Split(':')[1].Trim();
                                    }
                                }
                                displaySplits.Add(objNotePadData);

                            }
                        }
                        else
                        {

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();

                    }
                    return displaySplits;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string CampareMT(string mt, string strtiny, string strdisplay)
        {
            string ResultMT = string.Empty;
            try
            {

                string ScriptFile = _configuration.GetValue<string>("ReadNotePad");
                string root = Path.Combine(ScriptFile + strtiny);
                string objSwsMT = mt.Substring(2, 4);
                string objSwsMO = mt.Substring(6, 11);
                var subdirectoryEntries = Directory.GetDirectories(root);
                string[] subdirs = subdirectoryEntries.Select(Path.GetFileName).ToArray();
                foreach (var item in subdirs)
                {
                    string scriptMT = item.Substring(13, item.Length - 24).ToString();
                    string scriptMO = item.Substring(0, 11).ToString();
                    if (objSwsMT == scriptMT && objSwsMO == scriptMO)
                    {
                        ResultMT = item;
                    }
                }
            }
            catch (Exception ex)
            {

                ex.Message.ToString();
            }
            return ResultMT;

        }
    }
}
