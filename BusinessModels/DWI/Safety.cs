using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class Safety
    {
        public int Id { get; set; }
        public string SafetyCategory { get; set; }
        public string SafetyEquipment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Mode { get; set; }
    }

    public class SafetyMapping
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public string MT { get; set; }
        public string Stage { get; set; }
        public string SafetyDescription { get; set; }
        public IFormFile? SafetyPicFile { get; set; }
        public string SafetyPic { get; set; }
        public string SafetyPicPath { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? RowNumber { get; set; }
        public string Mode { get; set; }
    }

}
