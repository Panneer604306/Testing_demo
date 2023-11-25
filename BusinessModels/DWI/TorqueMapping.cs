using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class TorqueMapping
    {
        public int Id { get; set; }
        public string MT { get; set; }
        public string Series { get; set; }
        public string Stage { get; set; }
        public string Display { get; set; }
        public string Torque { get; set; }
        public IFormFile? TorquePicFile { get; set; }
        public string TorquePicPath { get; set; }
        public string TorquePic { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? RowNumber { get; set; }
        public string Mode { get; set; }
    }
}
