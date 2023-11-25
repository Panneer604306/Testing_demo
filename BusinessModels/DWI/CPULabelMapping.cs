using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class CPULabelMapping
    {
        public int Id { get; set; }
        
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string CPULabelType { get; set; }
        public IFormFile? CPULabelPicFile { get; set; }
        public string CPULabelPic { get; set; }
        public string CPULabelPicPath { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? RowNumber { get; set; }
        public string Mode { get; set; }
    }
}
