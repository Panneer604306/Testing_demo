using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class Client
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public string Product { get; set; }
        public string MT { get; set; }
        public string MTM { get; set; }
        public string Line { get; set; }
        public string Tiny { get; set; }
        public string Display { get; set; }
        public string Stage { get; set; }
        public string Assembly_FPY { get; set; }
        public string Packing_FPY { get; set; }
        public string Line_RTY { get; set; }
        public string Testing_FPY { get; set; }
        public string Warning { get; set; }
        public string CPULabelPic { get; set; }
        public string OSLabelPic { get; set; }
        public string GraphicPic { get; set; }
        
        public List<GetByClientVideo> ListByVideo { get; set; }
        public List<GetByClientPart> ListByPart { get; set; }
        public List<GetByClientTorque> ListByTorque { get; set; }
        public List<GetByClientSafety> ListBySafety { get; set; }
    }
    public class GetStageList
    {
        public int Id { get; set; }
        public string Stage { get; set; }
    }

    public class GetClientDisplay
    {
        public int Id { get; set; }
        public string ClientDisplay { get; set; }
        public string Line { get; set; }
        public string Type { get; set; }

    }

    public class GetByClientVideo
    {
        public string Video { get; set; }
        public string Sequence { get; set; }
        public string VideoPath { get; set; }
    }
    public class GetByClientPart
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string PartPic { get; set; }
        public string PartPicPath { get; set; }
    }
    public class GetByClientTorque
    {
        public int Id { get; set; }
        public string Torque { get; set; }
        public string TorquePic { get; set; }
        public string TorquePicPath { get; set; }
    }
    public class GetByClientSafety
    {
        public int Id { get; set; }
        public string SafetyDescription { get; set; }
        public string SafetyPic { get; set; }
        public string SafetyPicPath { get; set; }
    }
}
