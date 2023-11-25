using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessModels.DWI
{
    public class OSLabelMapping
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string OSLabelType { get; set; }
        public IFormFile? OSLabelPicFile { get; set; }
        public string OSLabelPic { get; set; }
        public string OSLabelPicPath { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? RowNumber { get; set; }
        public string Mode { get; set; }







    }
}
