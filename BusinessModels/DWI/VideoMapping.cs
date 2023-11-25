using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BusinessModels.DWI
{
    public class VideoMapping
    {
        public int Id { get; set; }
        public string MT { get; set; }
        public string Series { get; set; }
        public string? ItemCode { get; set; }
        public string Tiny { get; set; }
        public string Display { get; set; }
        public IFormFile VideoFile { get; set; }
        public string Video { get; set; }
        public string VideoPath { get; set; }
        public string Sequence { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? RowNumber { get; set; }
        public string Mode { get; set; }

    }
    public class PartPic
    {
        public string MT { get; set; }
        public string PartPicture { get; set; }
    }
}
